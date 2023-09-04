using System;
using Items;
using Project.Scripts.Infrastructure;
using UnityEngine;

namespace Project.Scripts.Core.Features.Minions
{
    [Serializable]
    public struct DeathReward : IComponent
    {
        [SerializeReference]
        private IPack _pack;
    }
}