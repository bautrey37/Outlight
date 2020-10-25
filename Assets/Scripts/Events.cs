using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Action<int> OnSetMoney;
    public static void SetMoney(int value) => OnSetMoney?.Invoke(value);
    public static event Action<int> OnAddMoney;
    public static void AddMoney(int value) => OnAddMoney?.Invoke(value);
    public static void RemoveMoney(int value) => OnAddMoney?.Invoke(-value);

    public static event Func<int> OnRequestMoney;
    public static int RequestMoney() => OnRequestMoney?.Invoke() ?? 0;


    public static event Action<StructureData> OnStructureSelected;
    public static void SelectStructure(StructureData structure) => OnStructureSelected?.Invoke(structure);


}
