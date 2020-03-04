public enum ITEMCATEGORY
{
    None,
    WEAPON = 1000,
    Bow,
    Raiper,
    staff,
    Gun,
    Sword,
    Axe,

    ARMOR = 2000,
    Heavy,
    Light,
    Vest,
    Shield,
    Hat,
    Glove,
    Boot,

    ACCESSORY = 3000,

    CONSUMEPTIONITEM = 4000,
    Heal,
    Revive,
    Spent,

    EQUIPITEM = 5000,
    DropItem = 6000,
}

#region 안씀
//public enum WEAPON
//{
//    Bow = 1001,
//    Raiper,
//    staff,
//    Gun,
//    Sword,
//    Axe,
//    Last = Axe
//}
//public enum ARMOR
//{
//    Heavy
//, Light
//, Vest
//, Shield
//, Hat
//, Glove
//, Boot
//,
//}

//public enum ConItem
//{
//    Heal,
//    Revive,
//}
//public enum Acc
//{
//    Accessory,
//}
#endregion

public enum WEAPON_ATK_KIND
{
    Cut,
    Melee,
    Bash,
}

public enum PlusProperty
{
    None,
    HP,
    WIS,
    TP,
    AGI,
    LUC,
    STR,
    VIT,
    INT,
}

public enum ShopCategory
{
    WEAPON = 1000,
    Bow,
    Rapier,
    Staff,
    Gun,
    Sword,
    Axe,

    ARMOR = 2000,
    Heavy,
    Light,
    Vest,
    Shield,
    Helmet,
    Glove,
    Boot,

    ACCESSORY = 3000,
    CONSUMEPTIONITEM = 4000,
    Heal,
    Revive,
    EQUIPITEM = 5000,
    DropItem = 6000,
}