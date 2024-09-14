using Slimes;
using Slimes.Enemies;
using UnityEngine;
using UnityEngine.Events;
using WorldObjects;

namespace Events.Internal
{
    public class SlimeEvents : MonoBehaviour
    {
        public UnityAction<Bait> BaitDetection;
        public UnityAction<Bait> BaitCollision;
        public UnityAction<Slime> EnemyDetected;
        public UnityAction<Slime> SlimeCollision;
        public UnityAction<SlimeAI> SlimeCollisionPl;
        public UnityAction<float> SizeIncrease;
        public UnityAction<Slime> EnemyLost;
    }
}