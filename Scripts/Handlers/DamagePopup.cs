using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace LB {

    public class DamagePopup : MonoBehaviour{

        public GameObject DamagePopupPrefab;
        public GameObject DamagePopupHandler;
        private GameObject DamagePopupItem;
        private TextMeshPro TextItem;
        private float popupTTL = 1f;
        private int order = 0;

        [Header("Damage popup colors")]
        public Color PhysicalDamageColor = new Color(0.849f, 0.506f, 0.000f, 1f);
        public Color MagicalDamageColor = new Color(0.000f, 0.612f, 1.000f, 1f);
        public Color FlatDamageColor = new Color(0.726f, 0.726f, 0.726f, 1f);
        [Header("Critical popup colors")]
        public Color CriticalPhysicalDamageColor = new Color(0.783f, 0.217f, 0.000f, 1f);
        public Color CriticalMagicalDamageColor = new Color(0.000f, 0.252f, 1.000f, 1f);
        public Color CriticalFlatDamageColor = new Color(1.000f, 1.000f, 1.000f, 1f);

        private void LateUpdate() {
            ManageUIOrientation();    
        }

        private void ManageUIOrientation(){
            Quaternion lookRotation = Camera.main.transform.rotation;
            DamagePopupHandler.transform.rotation = lookRotation;
        }

        private void SetupText(string value, DamageTypes type, bool criticalHit){
            TextItem.sortingOrder = order++;
            switch(type){
                case DamageTypes.Physical:
                    TextItem.faceColor = criticalHit ? CriticalPhysicalDamageColor : PhysicalDamageColor;
                    break;
                case DamageTypes.Magical:
                    TextItem.faceColor = criticalHit ? CriticalMagicalDamageColor : MagicalDamageColor;
                    break;
                case DamageTypes.Flat:
                    TextItem.faceColor = criticalHit ? CriticalFlatDamageColor : FlatDamageColor;
                    break;
                default:
                    TextItem.faceColor = criticalHit ? CriticalFlatDamageColor : FlatDamageColor;
                    break;
            }
            TextItem.text = value;
        }

        public void InstantiateDamage(string value, DamageTypes type, bool criticalHit){
            DamagePopupItem = Instantiate(DamagePopupPrefab, DamagePopupHandler.transform);
            TextItem = DamagePopupItem.transform.GetComponent<TextMeshPro>();
            SetupText(value, type, criticalHit);
            Destroy(DamagePopupItem, popupTTL);
        }

       
    }

}

