public interface IDamageAble
{
    void GetDamage(float Damage);
}
public interface IHP
{
    void HealHP(float H);
    void MaxHPUP(float H);
}
public interface IPlayerSkill
{
    public void SkillF();
    public void SkillS();
}
