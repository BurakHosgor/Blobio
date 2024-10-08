﻿using Events;
using Slimes.Enemies;
using Slimes.Pathfinding;
using UnityEngine;
using WorldObjects;

namespace Slimes.Player
{
    public class Player : Slime
    {
        [SerializeField] private PlayerPathSetter _playerPathSetter;

        protected override void IncreaseSize(int size)
        {
            base.IncreaseSize(size);
            PlayerEvents.SizeIncreased?.Invoke(size);
        }

        protected override void Pause()
        {
            _playerPathSetter.Pause();
        }

        protected override void UnPause()
        {
            _playerPathSetter.UnPause();
        }

        protected override void RegisterEvents()
        {
            base.RegisterEvents();
            SlimeEvents.BaitCollision += OnBaitCollision;
            SlimeEvents.SlimeCollisionPl += OnSlimeCollisionPl;
        }

        protected override void OnSlimeCollisionPl(SlimeAI enemySlime)
        {
            base.OnSlimeCollisionPl(enemySlime);
            enemySlime.Eaten();
            PlayerEvents.PlayerBaitConsume?.Invoke(Score);
        }
       
        protected override void OnBaitCollision(Bait colBait)
        {
            base.OnBaitCollision(colBait);
            PlayerEvents.PlayerBaitConsume?.Invoke(Score);
        }
    
        protected override void UnRegisterEvents()
        {
            base.UnRegisterEvents();
            SlimeEvents.BaitCollision -= OnBaitCollision;
            SlimeEvents.SlimeCollisionPl -= OnSlimeCollisionPl;
        }
    }
}