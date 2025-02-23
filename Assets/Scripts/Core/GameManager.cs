using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameManager : MonoBehaviour
{
    [Inject] private PlayerManager _playerManager;
    [Inject] private EnemyManager _enemyManager;
}
