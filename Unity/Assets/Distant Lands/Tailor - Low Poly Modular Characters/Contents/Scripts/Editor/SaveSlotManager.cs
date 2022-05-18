using UnityEngine;
using UnityEditor;

namespace DistantLands
{
    public class SaveSlotManager : MonoBehaviour
    {

        [MenuItem("Distant Lands/Tailor/Clear Save Slots")]
        static void ClearSlots()
        {

            if (EditorUtility.DisplayDialog("Are you sure you want to clear the save files?", "This action can not be undone.", "Clear Saves", "Cancel"))
            {

                for (int slot = 1; slot <= 6; slot++)
                {



                    PlayerPrefs.SetString("Tailor Slot " + slot, "");


                }

                PlayerPrefs.Save();

            }

        }
    }
}