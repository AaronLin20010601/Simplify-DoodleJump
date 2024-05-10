using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The game manager which control the spawn and destroy of all objects on the map
public class GameManager : MonoBehaviour
{
    public Transform player;
    public int randomize;

    // parameters relative with platform
    public GameObject platform_green_prefab;
    public GameObject platform_brown_prefab;
    public bool last_is_brown = false;
    public GameObject platform_blue_prefab;
    public GameObject platform_gray_prefab;
    public bool last_is_gray = false;
    public GameObject platform_white_prefab;
    public GameObject platform_yellow_prefab;
    public GameObject[] platform = new GameObject[50];
    public int platformCount = 50;
    public float[] platformYposition = new float[50];
    public Vector3 spawnPlatformPosition = new Vector3();

    // parameters relative with item   
    public GameObject spring_prefab;
    public GameObject hat_prefab;
    public GameObject rocket_prefab;
    public GameObject[] item = new GameObject[50];
    public int itemCount = 50;
    public int itemIndex = 0;
    public float[] itemYposition = new float[50];
    public Vector3 spawnItemPosition = new Vector3();

    //parameters relative with monster
    public GameObject small_monster_prefab;
    public GameObject big_monster_prefab;
    public GameObject[] monster = new GameObject[50];
    public int monsterCount = 50;
    public int monsterIndex = 0;
    public float[] monsterYposition = new float[50];
    public Vector3 spawnMonsterPosition = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy faraway platform and create new platform
        for (int j = 0; j < platformCount; j++)
        {
            if (player.position.y - platformYposition[j] > 30f)
            {
                Destroy(platform[j]);
                DetermineSpawnPosition(j);
                if (player.position.y <= 200f)
                {
                    PhaseOneSpawn(j);
                }
                else if (player.position.y > 200f && player.position.y <= 400f)
                {
                    PhaseTwoSpawn(j);
                }
                else if (player.position.y > 400f && player.position.y <= 800f)
                {
                    PhaseThreeSpawn(j);
                }
                else if (player.position.y > 800f && player.position.y <= 1200f)
                {
                    PhaseFourSpawn(j);
                }
                else
                {
                    PhaseFiveSpawn(j);
                }
            }
        }
        // Destroy faraway item
        for (int k = 0; k < itemCount; k++)
        {
            if (player.position.y - itemYposition[k] > 30f)
            {
                Destroy(item[k]);
            }
        }
        // Destroy faraway monster
        for (int l = 0; l < monsterCount; l++)
        {
            if (player.position.y - monsterYposition[l] > 30f)
            {
                Destroy(monster[l]);
            }
        }
    }

    // Determine the spawn position of platform
    public void DetermineSpawnPosition(int index)
    {
        if (player.position.y <= 200f)
        {
            spawnPlatformPosition.y += Random.Range(.5f, 2f);
        }
        else if (player.position.y > 200f && player.position.y <= 400f)
        {
            spawnPlatformPosition.y += Random.Range(1f, 2.25f);
        }
        else if (player.position.y > 400f && player.position.y <= 600f)
        {
            spawnPlatformPosition.y += Random.Range(1.5f, 2.5f);
        }
        else if (player.position.y > 600f && player.position.y <= 800f)
        {
            spawnPlatformPosition.y += Random.Range(2f, 2.75f);
        }
        else if (player.position.y > 800f && player.position.y <= 1000f)
        {
            spawnPlatformPosition.y += Random.Range(2.5f, 3f);
        }
        else
        {
            spawnPlatformPosition.y += Random.Range(3f, 3.25f);
        }
        spawnPlatformPosition.x = Random.Range(-2.7f, 2.7f);
        platformYposition[index] = spawnPlatformPosition.y;
    }

    // First wave of platform and item spawn before game start
    public void StartSpawn()
    {
        for (int i = 0; i < platformCount; i++)
        {
            spawnPlatformPosition.y += Random.Range(.5f, 2f);
            spawnPlatformPosition.x = Random.Range(-2.7f, 2.7f);
            platformYposition[i] = spawnPlatformPosition.y;
            randomize = Random.Range(0, 1000);
            if (randomize < 100)
            {
                platform[i] = Instantiate(platform_blue_prefab, spawnPlatformPosition, Quaternion.identity);
            }
            else
            {
                platform[i] = Instantiate(platform_green_prefab, spawnPlatformPosition, Quaternion.identity);
            }
        }
    }

    // The spawn type in phase one
    public void PhaseOneSpawn(int index)
    {
        randomize = Random.Range(0, 1000);
        if (randomize < 150)
        {
            platform[index] = Instantiate(platform_blue_prefab, spawnPlatformPosition, Quaternion.identity);
        }
        else if (last_is_brown == false && randomize >= 150 && randomize < 450)
        {
            platform[index] = Instantiate(platform_brown_prefab, spawnPlatformPosition, Quaternion.identity);
            last_is_brown = true;
        }
        else
        {
            platform[index] = Instantiate(platform_green_prefab, spawnPlatformPosition, Quaternion.identity);
            randomize = Random.Range(0, 1000);
            if (randomize < 150)
            {
                SummonItem(spring_prefab);
            }
            else if (randomize >= 150 && randomize < 185)
            {
                SummonItem(hat_prefab);
            }
            else if (randomize >= 185 && randomize < 200)
            {
                SummonItem(rocket_prefab);
            }
            last_is_brown = false;
        }
        randomize = Random.Range(0, 1000);
        if (randomize < 50)
        {
            SummonMonster(small_monster_prefab);
        }
        else if (randomize >= 50 && randomize < 55)
        {
            SummonMonster(big_monster_prefab);
        }
    }

    // The spawn type in phase two
    public void PhaseTwoSpawn(int index)
    {
        randomize = Random.Range(0, 1000);
        if (randomize < 250)
        {
            platform[index] = Instantiate(platform_blue_prefab, spawnPlatformPosition, Quaternion.identity);
        }
        else
        {
            platform[index] = Instantiate(platform_green_prefab, spawnPlatformPosition, Quaternion.identity);
            randomize = Random.Range(0, 1000);
            if (randomize < 125)
            {
                SummonItem(spring_prefab);
            }
            else if (randomize >= 125 && randomize < 160)
            {
                SummonItem(hat_prefab);
            }
            else if (randomize >= 160 && randomize < 175)
            {
                SummonItem(rocket_prefab);
            }
        }
        randomize = Random.Range(0, 1000);
        if (randomize < 50)
        {
            SummonMonster(small_monster_prefab);
        }
        else if (randomize >= 50 && randomize < 60)
        {
            SummonMonster(big_monster_prefab);
        }
    }

    // The spawn type of phase three
    public void PhaseThreeSpawn(int index)
    {
        randomize = Random.Range(0, 1000);
        if (randomize < 200)
        {
            platform[index] = Instantiate(platform_blue_prefab, spawnPlatformPosition, Quaternion.identity);
        }
        else if (last_is_gray == false && randomize >= 200 && randomize < 250)
        {
            platform[index] = Instantiate(platform_gray_prefab, spawnPlatformPosition, Quaternion.identity);
            last_is_gray = true;
        }
        else if (randomize >= 250 && randomize < 700)
        {
            platform[index] = Instantiate(platform_yellow_prefab, spawnPlatformPosition, Quaternion.identity);
        }
        else
        {
            platform[index] = Instantiate(platform_green_prefab, spawnPlatformPosition, Quaternion.identity);
            randomize = Random.Range(0, 1000);
            if (randomize < 125)
            {
                SummonItem(spring_prefab);
            }
            else if (randomize >= 125 && randomize < 150)
            {
                SummonItem(hat_prefab);
            }
            else if (randomize >= 150 && randomize < 160)
            {
                SummonItem(rocket_prefab);
            }
            last_is_gray = false;
        }
        randomize = Random.Range(0, 1000);
        if (randomize < 20)
        {
            SummonMonster(small_monster_prefab);
        }
        else if (randomize >= 20 && randomize < 25)
        {
            SummonMonster(big_monster_prefab);
        }
    }

    // The spawn type of phase four
    public void PhaseFourSpawn(int index)
    {
        randomize = Random.Range(0, 1000);
        if (randomize < 250)
        {
            platform[index] = Instantiate(platform_blue_prefab, spawnPlatformPosition, Quaternion.identity);
        }
        else if (last_is_gray == false && randomize >= 250 && randomize < 300)
        {
            platform[index] = Instantiate(platform_gray_prefab, spawnPlatformPosition, Quaternion.identity);
            last_is_gray = true;
        }
        else if (randomize >= 300 && randomize < 400)
        {
            platform[index] = Instantiate(platform_white_prefab, spawnPlatformPosition, Quaternion.identity);
        }
        else
        {
            platform[index] = Instantiate(platform_green_prefab, spawnPlatformPosition, Quaternion.identity);
            randomize = Random.Range(0, 1000);
            if (randomize < 90)
            {
                SummonItem(spring_prefab);
            }
            else if (randomize >= 90 && randomize < 105)
            {
                SummonItem(hat_prefab);
            }
            else if (randomize >= 105 && randomize < 110)
            {
                SummonItem(rocket_prefab);
            }
            last_is_gray = false;
        }
        randomize = Random.Range(0, 1000);
        if (randomize < 15)
        {
            SummonMonster(small_monster_prefab);
        }
        else if (randomize >= 15 && randomize < 30)
        {
            SummonMonster(big_monster_prefab);
        }
    }

    // The spawn type of phase five
    public void PhaseFiveSpawn(int index)
    {
        randomize = Random.Range(0, 1000);
        if (randomize < 150)
        {
            platform[index] = Instantiate(platform_blue_prefab, spawnPlatformPosition, Quaternion.identity);
        }
        else if (last_is_gray == false && randomize >= 150 && randomize < 200)
        {
            platform[index] = Instantiate(platform_gray_prefab, spawnPlatformPosition, Quaternion.identity);
            last_is_gray = true;
        }
        else if (randomize >= 200 && randomize < 350)
        {
            platform[index] = Instantiate(platform_white_prefab, spawnPlatformPosition, Quaternion.identity);
        }
        else if (randomize >= 350 && randomize < 500)
        {
            platform[index] = Instantiate(platform_yellow_prefab, spawnPlatformPosition, Quaternion.identity);
        }
        else
        {
            platform[index] = Instantiate(platform_green_prefab, spawnPlatformPosition, Quaternion.identity);
            randomize = Random.Range(0, 1000);
            if (randomize < 90)
            {
                SummonItem(spring_prefab);
            }
            else if (randomize >= 90 && randomize < 105)
            {
                SummonItem(hat_prefab);
            }
            else if (randomize >= 105 && randomize < 110)
            {
                SummonItem(rocket_prefab);
            }
            last_is_gray = false;
        }
        randomize = Random.Range(0, 1000);
        if (randomize < 10)
        {
            SummonMonster(small_monster_prefab);
        }
        else if (randomize >= 10 && randomize < 30)
        {
            SummonMonster(big_monster_prefab);
        }
    }

    // Create item object
    public void SummonItem(GameObject item_type)
    {
        if (itemIndex == itemCount)
        {
            itemIndex = 0;
        }
        if (item_type == spring_prefab)
        {
            spawnItemPosition.y = spawnPlatformPosition.y + 0.3f;
        }
        else if (item_type == hat_prefab)
        {
            spawnItemPosition.y = spawnPlatformPosition.y + 0.25f;
        }
        else if (item_type == rocket_prefab)
        {
            spawnItemPosition.y = spawnPlatformPosition.y + 0.35f;
        }       
        spawnItemPosition.x = Random.Range(spawnPlatformPosition.x - 0.3f, spawnPlatformPosition.x + 0.3f);
        item[itemIndex] = Instantiate(item_type, spawnItemPosition, Quaternion.identity);
        itemYposition[itemIndex] = spawnItemPosition.y;
        itemIndex++;
    }

    // Create monster
    public void SummonMonster(GameObject monster_type)
    {
        if (monsterIndex == monsterCount)
        {
            monsterIndex = 0;
        }
        spawnMonsterPosition.x = Random.Range(-2.7f, 2.7f);
        spawnMonsterPosition.y = player.position.y + 15f;
        monster[monsterIndex] = Instantiate(monster_type, spawnMonsterPosition, Quaternion.identity);
        monsterYposition[monsterIndex] = spawnMonsterPosition.y;
        monsterIndex++;
    }
}
