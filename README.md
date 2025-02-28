# Лабораторна робота 3

Принципи, дотримані в рамках лабораторної роботи:

- **KISS (Keep It Simple, Stupid)**  
  Код написано просто, кожен клас виконує лише одну задачу. Наприклад, клас `Product` відповідає лише за товар, а `Warehouse` — за зберігання товарів. Також немає зайвих перевантажень або складних конструкцій.  
  [Приклад: `Product` та `Warehouse`](https://github.com/oleg-ischuk/Library/blob/main/Library/Product.cs)  
  Рядки коду: [12-26](https://github.com/oleg-ischuk/Library/blob/main/Library/Product.cs#L12-L26), [6-16](https://github.com/oleg-ischuk/Library/blob/main/Library/Warehouse.cs#L6-L16)

- **YAGNI (You Aren't Going to Need It)**  
  У коді реалізовано лише необхідний функціонал для роботи складу, обліку надходжень та відвантажень. Немає зайвих методів або класів, які не використовуються в поточному завданні.  
  [Приклад: `RegisterIncome`, `RegisterOutcome`](https://github.com/oleg-ischuk/Library/blob/main/Library/Reporting.cs)  
  Рядки коду: [14-23](https://github.com/oleg-ischuk/Library/blob/main/Library/Reporting.cs#L14-L23), [26-36](https://github.com/oleg-ischuk/Library/blob/main/Library/Reporting.cs#L26-L36)

- **DRY (Don't Repeat Yourself)**  
  Код не містить дублювання логіки. Всі операції з товарами обробляються через єдину загальну структуру даних (словник).  
  [Приклад: методи `RegisterIncome` та `RegisterOutcome`](https://github.com/oleg-ischuk/Library/blob/main/Library/Reporting.cs)  
  Рядки коду: [14-23](https://github.com/oleg-ischuk/Library/blob/main/Library/Reporting.cs#L14-L23), [26-36](https://github.com/oleg-ischuk/Library/blob/main/Library/Reporting.cs#L26-L36)

- **Fail Fast**  
  У класі `Reporting` використовуються перевірки для виявлення можливих помилок на ранньому етапі, наприклад, перевірка на наявність товару перед його відвантаженням.  
  [Приклад: `RegisterOutcome`](https://github.com/oleg-ischuk/Library/blob/main/Library/Reporting.cs)  
  Рядки коду: [26-36](https://github.com/oleg-ischuk/Library/blob/main/Library/Reporting.cs#L26-L36)

- **Composition Over Inheritance**  
  Клас `Reporting` використовує інстанс класу `Warehouse` через композицію, а не через наслідування. Це дозволяє більш гнучко керувати залежностями.  
  [Приклад: композиція в `Reporting`](https://github.com/oleg-ischuk/Library/blob/main/Library/Reporting.cs)  
  Рядки коду: [8-11](https://github.com/oleg-ischuk/Library/blob/main/Library/Reporting.cs#L8-L11)

- **SOLID (S - Single Responsibility Principle)**  
  Кожен клас виконує лише одну задачу: `Product` відповідає за товари, `Money` за гроші, `Warehouse` за зберігання товарів, а `Reporting` за ведення обліку та звітність.  
  [Приклад: `Product`, `Money`, `Warehouse`](https://github.com/oleg-ischuk/Library/blob/main/Library/Product.cs)  
  Рядки коду: [6-26](https://github.com/oleg-ischuk/Library/blob/main/Library/Product.cs#L6-L26)  
  [Приклад: `Money`](https://github.com/oleg-ischuk/Library/blob/main/Library/Money.cs)  
  Рядки коду: [6-18](https://github.com/oleg-ischuk/Library/blob/main/Library/Money.cs#L6-L18)  
  [Приклад: `Warehouse`](https://github.com/oleg-ischuk/Library/blob/main/Library/Warehouse.cs)  
  Рядки коду: [6-16](https://github.com/oleg-ischuk/Library/blob/main/Library/Warehouse.cs#L6-L16)

- **SOLID (O - Open/Closed Principle)**  
  Класи можуть бути розширені, але існуючий функціонал не змінюється. Наприклад, можна додати нові методи в `Product` для спеціальних операцій, але клас не потребує переписування.  
  [Приклад: розширення класу `Product`](https://github.com/oleg-ischuk/Library/blob/main/Library/Product.cs)  
  Рядки коду: [6-26](https://github.com/oleg-ischuk/Library/blob/main/Library/Product.cs#L6-L26)

- **Program to Interfaces, not Implementations**  
  У коді не використовується пряме програмування до реалізацій конкретних класів, що дозволяє легко змінювати реалізації без зміни зовнішнього інтерфейсу.  
  [Приклад: програмування до інтерфейсів в `Product`](https://github.com/oleg-ischuk/Library/blob/main/Library/Product.cs)  
  Рядки коду: [6-26](https://github.com/oleg-ischuk/Library/blob/main/Library/Product.cs#L6-L26)
