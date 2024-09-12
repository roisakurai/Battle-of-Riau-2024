using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TUTOR_RemoveTutorialHand : MonoBehaviour
{
    public GameObject LeftHand; // Referensi ke GameObject tangan tutorial

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Mendapatkan komponen XRGrabInteractable dari objek ini
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Mendaftarkan event saat obor di-grab atau dilepaskan
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Ketika obor dipegang, sembunyikan tangan tutorial
        LeftHand.SetActive(false);
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        // Ketika obor dilepaskan, tangan tutorial bisa ditampilkan kembali (opsional)
        LeftHand.SetActive(true);
    }

    private void OnDestroy()
    {
        // Melepaskan event listener untuk menghindari kebocoran memori
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }
}
