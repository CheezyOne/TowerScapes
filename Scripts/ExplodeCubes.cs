using UnityEngine;

public class ExplodeCubes : MonoBehaviour
{
    public GameObject cubeToDestroy, TurningToTheLeftButton, TurningToTheRightButton;
    public GameObject restartButton, explosion;
    private bool CollisionSet=false;
    public float Force = 100;
    private void OnCollisionEnter(Collision collision)
    {
        if (((collision.gameObject.tag == "Cube") && (!CollisionSet)))
        {
            for (int i=collision.transform.childCount-1;i>=0;i--)
            {
                Transform child = collision.transform.GetChild(i);
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Force, Vector3.up,10);//Вектор 3
                child.SetParent(null);
            }
            Destroy(cubeToDestroy);
            Destroy(TurningToTheLeftButton);
            Destroy(TurningToTheRightButton);
            restartButton.SetActive(true);
            //Camera.main.gameObject.transform.position -= new Vector3(0, 0, 3f);двигаем камеру назад
            Camera.main.gameObject.AddComponent<CameraShake>();
            if (ItMustBeCubeToDestroy())
            {
                GameObject newVfx = Instantiate(explosion, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                Destroy(newVfx, 1.5f);
            }
            else
            {
                GameObject newVfx = Instantiate(explosion, new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, collision.contacts[0].point.z), Quaternion.identity) as GameObject;
                Destroy(newVfx, 1.5f);
            }
            if (PlayerPrefs.GetString("music") == "Yes")
            {
                GetComponent<AudioSource>().Play();
            } 
            Destroy(collision.gameObject);
            CollisionSet = true;
        }
    }
    private bool ItMustBeCubeToDestroy()
    {
        if (cubeToDestroy.transform.position.x < 10 && cubeToDestroy.transform.position.x > -10)
            return false;
        else 
            return true;
    }
}
