﻿using UnityEngine;

public static class LayerUtils
{
    public static int Player = LayerMask.NameToLayer("Player");
    public static int Enemy = LayerMask.NameToLayer("Enemy");
    public static int Ground = LayerMask.NameToLayer("Ground");
}