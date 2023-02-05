﻿using Inworld.Grpc;
using System.Collections.Concurrent;
using System.Linq;
using UnityEngine;
using PacketId = Inworld.Packets.PacketId;
namespace Inworld.Model
{
    public class InworldLipAnimation : MonoBehaviour
    {
        const int k_VisemeLength = 15;
        [SerializeField] FacialAnimationData m_FaceAnimData;
        [Range(0, 1)][SerializeField] float m_LipExpression = 0.7f;
        Vector2 m_CurrViseme = Vector2.zero;
        Vector2 m_LastViseme = Vector2.zero;
        float m_PassedTime;

        SkinnedMeshRenderer m_Skin;
        int m_VisemeIndex;
        /// <summary>
        ///     YAN: We use Vector2 to store viseme data.
        ///     Vector2.x ==> Viseme Index (-1 = continue, add to next viseme)
        ///     Vector2.y ==> Duration
        /// </summary>
        ConcurrentQueue<Vector2> m_VisemeMap = new ConcurrentQueue<Vector2>();

        #region Properties
        /// <summary>
        ///     Get/Set the Inworld Character this component used.
        /// </summary>
        public InworldCharacter Character { get; set; }
        #endregion

        void Awake()
        {
            Init();
        }
        void FixedUpdate()
        {
            m_PassedTime += Time.fixedDeltaTime;
            _MorphFace();
        }
        void OnEnable()
        {
            if (!Character || !Character.Audio)
                return;
            Character.Audio.OnAudioStarted += OnAudioStarted;
            Character.Audio.OnAudioFinished += OnAudioFinished;
        }
        void OnDisable()
        {
            Character.Audio.OnAudioStarted -= OnAudioStarted;
            Character.Audio.OnAudioFinished -= OnAudioFinished;
        }

        public void Init()
        {
            Character ??= GetComponent<InworldCharacter>();
            m_Skin ??= Character.GetComponentInChildren<SkinnedMeshRenderer>();
            m_VisemeMap ??= new ConcurrentQueue<Vector2>();
            m_VisemeMap.Clear();
            _MappingBlendShape();
        }
        void _Reset()
        {
            m_VisemeMap.Clear();
            m_CurrViseme = Vector2.zero;
            m_LastViseme = Vector2.zero;
            m_PassedTime = 0;
            _ShutMouth();
        }
        void _ShutMouth()
        {
            if (!m_Skin)
                return;
            m_Skin.SetBlendShapeWeight(m_VisemeIndex, 1);
            for (int i = 1; i < k_VisemeLength; i++)
            {
                m_Skin.SetBlendShapeWeight(m_VisemeIndex + i, 0);
            }
        }
        void _MorphFace()
        {
            if (!m_Skin)
                return;
            // 1. Move Out-dated Viseme to Last Viseme.
            if (m_PassedTime >= m_CurrViseme.y)
            {
                m_LastViseme = m_CurrViseme;
                m_CurrViseme = Vector2.zero;
            }
            // 2. Get New Viseme if Current Viseme is illegal.
            while (m_VisemeMap.Count > 0 && (m_CurrViseme.y == 0 || m_CurrViseme.x < 0))
            {
                m_VisemeMap.TryDequeue(out m_CurrViseme);
            }
            // 3. Do Morph.
            // Gradually decrease Last to 0
            if (m_LastViseme.y > 0 && m_LastViseme.x >= 0)
                _MorphViseme(m_LastViseme, false);
            // At the same time, gradually increase Current to 1.
            if (m_CurrViseme.y > 0 && m_CurrViseme.x >= 0)
                _MorphViseme(m_CurrViseme);
        }
        void _MorphViseme(Vector2 viseme, bool isIncreasing = true)
        {
            if (viseme.x == 0)
            {
                _ShutMouth(); // YAN: Shut Immediately.
                return;
            }
            int visemeIndex = m_VisemeIndex + (int)viseme.x;
            float lastBlendShapeWeight = m_Skin.GetBlendShapeWeight(visemeIndex);
            float scale = Time.fixedDeltaTime / (m_CurrViseme.y - m_LastViseme.y);
            if (scale <= 0)
                return;
            scale = isIncreasing ? scale : -scale;
            float newWeight = Mathf.Clamp(lastBlendShapeWeight + scale, 0, m_LipExpression);
            m_Skin.SetBlendShapeWeight(visemeIndex, newWeight);
        }
        void _MappingBlendShape()
        {
            if (!m_Skin)
                return;
            for (int i = 0; i < m_Skin.sharedMesh.blendShapeCount; i++)
            {
                if (m_Skin.sharedMesh.GetBlendShapeName(i) != "viseme_sil")
                    continue;
                m_VisemeIndex = i;
                Debug.Log($"Find Viseme Index {m_VisemeIndex}");
                break;
            }
        }
        void OnAudioStarted(PacketId ID)
        {
            _Reset();
            if (!Character || !Character.Audio || Character.Audio.IsMute)
                return;
            foreach (AdditionalPhonemeInfo phoneme in Character.Audio.CurrentChunk.PhonemeInfo)
            {
                PhonemeToViseme p2vRes = m_FaceAnimData.p2vMap.FirstOrDefault(p2v => p2v.phoneme == phoneme.Phoneme);
                int visemeIndex = p2vRes?.visemeIndex ?? -1;
                m_VisemeMap.Enqueue(new Vector2(visemeIndex, (float)phoneme.StartOffset.ToTimeSpan().TotalSeconds));
            }
        }
        void OnAudioFinished()
        {
            _Reset();
        }
    }
}
