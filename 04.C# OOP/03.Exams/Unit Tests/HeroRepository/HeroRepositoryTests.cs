using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    

    [Test]
    public void CreateHeroShouldReturnNull()
    {
        var heroRepository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void CreateHeroShouldThrowExceptionThatExist()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero("misho", 44);
        Assert.Throws<InvalidOperationException>(() => 
        {
            heroRepository.Create(hero);
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void CreateHeroSuccess()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero("misho", 44);
      var result =  heroRepository.Create(hero);
        Assert.AreEqual($"Successfully added hero misho with level 44", result);
    }

    [Test]
    public void RemoveShouldThrowExceptionWhenTryToRemoveNullName()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero(null, 44);
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(hero.Name));
    }

    [Test]
    public void RemoveSuccess()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero("misho", 44);
        heroRepository.Create(hero);
        var result = heroRepository.Remove(hero.Name);
        Assert.IsTrue(result);
   
    }

    [Test]
    public void HeroWithHighestLevelTrue()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero("misho", 44);
        var bob = new Hero("dido", 1000000);
        heroRepository.Create(bob);
        heroRepository.Create(hero);
        var result = heroRepository.GetHeroWithHighestLevel();
        Assert.Greater(result.Level, 44);

    }
    [Test]
    public void HeroName()
    {
        var heroRepository = new HeroRepository();
        var hero = new Hero("misho", 44);
        heroRepository.Create(hero);
        var result = heroRepository.GetHero(hero.Name);
        Assert.AreSame(hero, result);

    }
}
