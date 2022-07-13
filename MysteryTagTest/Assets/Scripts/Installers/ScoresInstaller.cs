using UnityEngine;
using Zenject;

public class ScoresInstaller : MonoInstaller<ScoresInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IScores>().To<Scores>().AsSingle();
    }
}