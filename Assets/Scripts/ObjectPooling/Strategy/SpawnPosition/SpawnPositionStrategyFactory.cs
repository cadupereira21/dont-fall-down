using System;
using System.Collections.Generic;
using System.ComponentModel;
using ObjectPooling.Strategy.Attributes;

namespace ObjectPooling.Strategy.SpawnPosition {
    public abstract class SpawnPositionStrategyFactory {
        private static readonly Dictionary<SpawnPosition, SpawnPositionStrategy> Strategies = new () {
                { SpawnPosition.FIXED, new FixedPositionSpawnStrategy() }, 
                { SpawnPosition.RANGE, new RangePositionSpawnStrategy() }
            };
        
        public static SpawnPositionStrategy GetStrategy(SpawnPosition position, SpawnPositionAttributeSo attributesSo) {
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