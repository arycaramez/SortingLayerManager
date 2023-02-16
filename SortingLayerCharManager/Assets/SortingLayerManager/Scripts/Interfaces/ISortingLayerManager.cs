using System.Collections.Generic;
using UnityEngine;
//Author: Ary Guilherme Pires Caramez. link: https://github.com/arycaramez

namespace SortingLayerManager
{
    public interface ISortingLayerManager {

        void ApplyList();

        void UpdateList();

        GameObject[] FindRenderer(GameObject gObj);

        List<string> GetSortingLayerNames();

        void SetSortingLayer(IMeshObjectElement meshElement);

        int GetSortingOrderByID(int tagID);

        int GetIdSubTagLayers(string tagRef);
    }
}
