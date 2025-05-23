﻿using Ugadaika.Domain.Contracts;
using Ugadaika.Domain.Interfaces;

namespace Ugadaika
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var validator = new NumberGenerator();
            var baseGenerator = new NumberGenerator();

            INumberGenerator generator = new EvenNumberGenerator(baseGenerator, validator);

            var game = new UgadaikaGame(generator, 1, 10);
            game.Play();
        }
    }
}

/*
 Принцип единственной ответственности. Каждый класс должен отвечать за что-то одно
У класса NumberGenerator задача только генерировать числа
У класса UgadaikaGame задача только отвечать за игру

 Принцип открытости/закрытости Мейера. Классы должны быть открыты для расширения, но закрыты для модификации


 Принцип подстановки Барбары Лисков. Классы наследники не противоречат базовому классу.
Вместо NumberGenerator можно было бы создать иной класс-наследник NumberGenerator, имплементирующий интерфейс INumberGenerator,
но, например, генерирующий только четные числа указанного диапазона.
Игра бы не сломалась, но изменились бы условия согласно новой бизнес-потребности.

 Принцип разделения интерфейсов. Интерфейсы более узкие и специализированные.
Генерацию числа и валидацию диапазона в виде интерфейсов разделили между собой, получив тем самым более гибкий фунцкионал.

 Принцип инверсии зависимостей.
Модели более высокого уровня зависят от абстракций, а абстракции не зависят от деталей.
Если добавить в EvenNumberGenerator зависимости, то от интерфейсов. Тогда любой класс, имплементирующий эти интерфейсы, подойдет в реализации.
 */