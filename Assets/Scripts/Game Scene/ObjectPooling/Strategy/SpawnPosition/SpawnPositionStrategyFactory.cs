using System;
using System.Collections.Generic;
using System.ComponentModel;
using Game_Scene.ObjectPooling.Strategy.Attributes;

namespace Game_Scene.ObjectPooling.Strategy.SpawnPosition {
    public abstract class SpawnPositionStrategyFactory {
        private static readonly Dictionary<Game_Scene.ObjectPooling.Strategy.SpawnPosition.SpawnPosition, SpawnPositionStrategy> Strategies = new () {
                { Game_Scene.ObjectPooling.Strategy.SpawnPosition.SpawnPosition.FIXED, new FixedPositionSpawnStrategy() }, 
                { Game_Scene.ObjectPooling.Strategy.SpawnPosition.SpawnPosition.RANGE, new RangePositionSpawnStrategy() }
            };
        
        public static SpawnPositionStrategy GetStrategy(Game_Scene.ObjectPooling.Strategy.SpawnPosition.SpawnPosition position, SpawnPositionAttributeSo attributesSo) {
            if (Strategies.Count == 0) {
                throw new InvalidOperationException("No strategies registered.");
            }

            if (!Strategies.TryGetValue(position, out SpawnPositionStrategy strategy)) {
                throw new InvalidEnumArgumentException($"There is no strategy registered for the '{position.ToString()}' position.");
            }

            strategy.Init(attributesSo);
            
            return strategy;
        }
    }
}