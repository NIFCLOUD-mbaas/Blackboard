using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;

public class UITests : MonoBehaviour
{
    [SetUp]
    public void init()
    {
        SceneManager.LoadScene("blackboard");
    }

    [UnityTest]
    public IEnumerator confirmBlackBoardUI()
    {
        var btnSaveGameObject = GameObject.Find("Save");
        Assert.IsNotNull(btnSaveGameObject, "Missing button Save");

        var bntGalleryGameObject = GameObject.Find("Gallery");
        Assert.IsNotNull(bntGalleryGameObject, "Missing button Gallery");

        var drawingPanelGameObject = GameObject.Find("DrawingPanel");
        Assert.IsNotNull(drawingPanelGameObject, "Missing DrawingPanel");
        var imageGameObject = GameObject.Find("Image");
        Assert.IsNotNull(imageGameObject, "Missing Image");

        yield return new WaitForSeconds(.1f);
    }

    [UnityTest]
    public IEnumerator testClickSave()
    {
        var btnSaveGameObject = GameObject.Find("Save");
        Assert.IsNotNull(btnSaveGameObject, "Missing button Save");

        var bntGalleryGameObject = GameObject.Find("Gallery");
        Assert.IsNotNull(btnSaveGameObject, "Missing button Gallery");

        var btnSave = btnSaveGameObject.GetComponent<Button>();
        btnSave.onClick.Invoke();

        yield return new WaitForSeconds(5);

        // Assert not change scene
        btnSaveGameObject = GameObject.Find("Save");
        bntGalleryGameObject = GameObject.Find("Gallery");
        Assert.IsNotNull(btnSaveGameObject, "Missing button Save");
        Assert.IsNotNull(bntGalleryGameObject, "Missing button Gallery");
    }

    [UnityTest]
    public IEnumerator testClickGallery()
    {
        var bntGalleryGameObject = GameObject.Find("Gallery");
        Assert.IsNotNull(bntGalleryGameObject, "Missing button Gallery");

        var bntGallery = bntGalleryGameObject.GetComponent<Button>();
        bntGallery.onClick.Invoke();

        yield return new WaitForSeconds(5);

        var btnBackGameObject = GameObject.Find("back");
        Assert.IsNotNull(btnBackGameObject, "Missing button Back from scene Gallery");

        var image1GameObj = GameObject.Find("Image1");
        Assert.IsNotNull(image1GameObj, "Missing Image1 from scene Gallery");

        var image2GameObj = GameObject.Find("Image2");
        Assert.IsNotNull(image2GameObj, "Missing Image1 from scene Gallery");

        var image3GameObj = GameObject.Find("Image3");
        Assert.IsNotNull(image3GameObj, "Missing Image1 from scene Gallery");

        var image4GameObj = GameObject.Find("Image4");
        Assert.IsNotNull(image4GameObj, "Missing Image1 from scene Gallery");
    }


    [TearDown]
    public void TearDown()
    {

    }
}
