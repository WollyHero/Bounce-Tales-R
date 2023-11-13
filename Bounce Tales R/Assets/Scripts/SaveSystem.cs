using UnityEngine;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour {
    // this is kinda  an usafe thing to do but is made for testing the savesystem. Later on ill
    // write some function to save.
    public SaveClass structure = new SaveClass(0, 0, 0, new List<int>());
    private void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            structure = structure.ParseToClass(Handlers.main.savefile_name);
            Handlers.main.EggsCount = structure.eggCount;
            Handlers.main.TimeElapsed = structure.timeElapsed;
            Handlers.main.checkpoint = structure.checkpoint;
            Handlers.main.id_to_unload = structure.Unload_obj;
            Debug.Log("Loaded SUCCEFULLY");
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            structure.eggCount = Handlers.main.EggsCount;
            structure.timeElapsed = Handlers.main.TimeElapsed;
            structure.checkpoint = Handlers.main.checkpoint;
            structure.Unload_obj = Handlers.main.id_to_unload;
            structure.WriteClass(structure, Handlers.main.savefile_name);
            Debug.Log("SAVED SUCCEFULLY");
        }
        if (Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.LeftShift)) {
            structure = new SaveClass(0, 0, 0, new List<int>());
            structure.WriteClass(structure, Handlers.main.savefile_name);
            Debug.Log("Cleaned SUCCEFULLY");
        }
    }
}
