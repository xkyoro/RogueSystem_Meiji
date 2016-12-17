using UnityEngine;
using System.Collections;

namespace Meiji {

  public enum WeaponType {
    Sword,
    Spear,
    Axe
  }

  public class Item {
    private int count;

    public int Count {
      get { return count; }
    }

    public Item() {
      count = 0;
    }

    public void Add() {
      count += 1;
    }

    public bool Use() {
      if (count > 0) {
        count -= 1;
        return true;
      }
      return false;
    }
  }

  public class ItemList {
    Meiji.Item potion;
    Meiji.Item marker;
    Meiji.Item atkPotion;
    Meiji.Item defPotion;

    public ItemList() {
      potion = new Meiji.Item();
      marker = new Meiji.Item();
      atkPotion = new Meiji.Item();
      defPotion = new Meiji.Item();
    }
  }

  public class Stats {
    private int hp;

    public int HP {
      get { return hp; }
    }

    public void DeductDamage(int value) {
      hp -= value;
    }

    private int def;

    public int Def {
      get { return def; }
    }

    public void ChangeDef(int value) {
      def = value;
    }

    private Meiji.WeaponType weaponType;

    public Meiji.WeaponType currentWeapon {
      get { return weaponType; }
    }

    private Meiji.ItemList items;

    public Meiji.ItemList itemList {
      get { return items; }
    }

    public Stats() {
      hp = 100;
      def = 10;
      weaponType = Meiji.WeaponType.Sword;
      items = new ItemList();
    }
  }

  public class PlayerStats : MonoBehaviour {

    private Meiji.Stats playerStats;

    public Meiji.Stats currentPlayerStats {
      get { return playerStats; }
      set { playerStats = value; }
    }

    void Start() {
      currentPlayerStats = new Meiji.Stats();
    }

    void Update() {

    }
  }
}
