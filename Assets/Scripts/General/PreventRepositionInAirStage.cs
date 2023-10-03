//Creado por : Fernando Alvarez
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PreventRepositionInAirStage : MonoBehaviour
{
    public AnchorInputListenerBehaviour inputListener;
    public MidAirPositionerBehaviour midAirPositioner;
    public GameObject mensajePlano;

    private void Awake()
    {
        mensajePlano.SetActive(false);
    }

    //Llamado por el evento OnTargetFound del GroundPlaneStage. 
    //Bloquea la reposicion del objeto. Para activar la jugabilidad.
    public void LockPlaneGround()
    {
        inputListener.enabled = false;
        midAirPositioner.enabled = false;
        mensajePlano.SetActive(false);
    }

    //Llamado por el evento OnTargetLost del GroundPlaneStage.
    //Posibilidad de activar con un boton para restablecer el reposicionamiento del plano.
    public void unLockPlaneGround()
    {
        inputListener.enabled = true;
        midAirPositioner.enabled = true;
        mensajePlano.SetActive(true);
    }
}
