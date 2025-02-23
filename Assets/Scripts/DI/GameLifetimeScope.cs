using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        var playerStats = Resources.Load<PlayerStats>("Stats/PlayerStats");
        var enemyPrefabDatabase = Resources.Load<EnemyPrefabDatabase>("Stats/EnemyPrefabDatabase");

        builder.RegisterInstance(playerStats).AsSelf();
        builder.RegisterInstance(enemyPrefabDatabase).AsSelf();
        builder.Register<EnemyFactory>(Lifetime.Singleton).As<ICharacterFactory>();
        builder.Register<PlayerManager>(Lifetime.Singleton);

        builder.Register<AttackingStrategyFactory>(Lifetime.Singleton);
        builder.Register<MovementStrategyFactory>(Lifetime.Singleton);
        builder.Register<ObjectPool>(Lifetime.Singleton);

        builder.Register<EnemyStateMachine>(Lifetime.Singleton);
        builder.Register<EnemyManager>(Lifetime.Singleton).AsSelf().As<ITickable>();
    }
}
