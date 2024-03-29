# Windows Forms

## [WF01_1_T01](/WF01_1_T01/)

1. Программа запрашивает у пользователя путь к файлу с символами Unicode. После чего программа копирует содержимое файла в новый файл, преобразовывая исходное содержимое в формат ANSI.

2. Посчитать количество названий фруктов в файле. Названия фруктов и путь к файлу пользователь вводит с клавиатуры. Названия фруктов и содержимое файла в формате Unicode.

-----

## [WF01_2_T01](/WF01_2_T01/)

Написать приложение, позволяющее вывести на экран краткое резюме с помощью последовательности окон сообщений (количество окон сообщений – не менее трёх).

На заголовке последнего окна сообщения должно отобразиться среднее число символов на странице (общее число символов в резюме поделить на количество окон сообщений).

-----

## [Wf01_2_t02](/Wf01_2_t02/)

Написать приложение, которое «угадывает» задуманное пользователем число от 1 до 100.

Для запроса к пользователю использовать окна сообщений.

После того, как число отгадано, необходимо вывести количество попыток, потребовавшихся для этого, и предоставить пользователю возможность сыграть еще раз, не завершая программу.

Окна сообщений следует оформить кнопками и иконками в соответствии с конкретной ситуацией.

-----

## [Wf01_3_t01](/Wf01_3_t01/)

Написать приложение, в котором ведётся подсчёт количества «кликов» левой, правой и средней кнопки мыши.

Обновляемую статистику необходимо выводить в заголовок окна.

-----

## [Wf01_3_t02](/Wf01_3_t02/)

Предположим, что существует прямоугольник, границы которого на 10 пикселей отстоят от границ клиентской области окна.

Необходимо при нажатии левой кнопки мыши выводить в заголовок окна сообщение о том, где произошел щелчок мышью: внутри прямоугольника, снаружи или на границе прямоугольника.

При нажатии правой кнопки мыши необходимо выводить в заголовок окна информацию о размере клиентской области окна (ширина и высота клиентской области окна).

-----

## [Wf01_4_t01](/Wf01_4_t01/)

Написати «Калькулятор» з використанням WinAPI

![Калькулятор](/Wf01_4_t01/Calculator_WinApi.png)

-----

## [Тема: Події миші](/Wf02_1_t01_%D0%9F%D1%80%D0%B8%D0%B1%D0%B0%D0%B2%D0%BA%D0%B0%20%D0%BA%20%D0%B7%D0%B0%D1%80%D0%BF%D0%BB%D0%B0%D1%82%D0%B5/)

Створіть додаток за поданим зразком

![ScreenShot](/Wf02_1_t01_%D0%9F%D1%80%D0%B8%D0%B1%D0%B0%D0%B2%D0%BA%D0%B0%20%D0%BA%20%D0%B7%D0%B0%D1%80%D0%BF%D0%BB%D0%B0%D1%82%D0%B5/ScreenShot01.png)

При наведенні миші на кнопку «Да» кнопка змінює своє місце розташування в межах видимої частини вікна. Користувач не повинен мати змогу натиснути на її. При зміні розмірів вікна кнопки повинні бути в межах вікна. При натисканні на кнопку «Нет», вивести повідомлення «Дякую за співпрацю».

## Результат
![ScreenShot](/Wf02_1_t01_%D0%9F%D1%80%D0%B8%D0%B1%D0%B0%D0%B2%D0%BA%D0%B0%20%D0%BA%20%D0%B7%D0%B0%D1%80%D0%BF%D0%BB%D0%B0%D1%82%D0%B5/ScreenShot02.png)

-----

## [Тема: Елементи: Label, Button, Edit](/Wf02_2_t01_%D0%90%D0%BD%D0%BA%D0%B5%D1%82%D0%B0/)

Завдання "Анкета". Завдання користувача ввести свої дані в форму.

При натисканні на кнопку дані з форми та дата заповнення анкети записуються до файлу та відображаються у блокноті (У файлі мають зберігатись всі анкети). Зовнішній вигляд програми:

![ScreenShot](/Wf02_2_t01_%D0%90%D0%BD%D0%BA%D0%B5%D1%82%D0%B0/ScreenShot01.png)

## Результат
![ScreenShot](/Wf02_2_t01_%D0%90%D0%BD%D0%BA%D0%B5%D1%82%D0%B0/ScreenShot02.png)

-----

## [Тема: LIST](/Wf03_1_t01_CheckedListBox/)

Створити програму за зразком:

![ScreenShot](/Wf03_1_t01_CheckedListBox/ScreenShot01.png)

Для програми розробити клас Студент з полями ПІБ та Вік.
При натисканні на кнопку додати створюється новий студент з полями з відповідних компонентів, який зберігається у список.
У компоненті CheckedListbox відображаються всі прізвища доданих студентів.
При виборі студентів автоматично підраховується середній вік вибраних.
При натисканні на кнопку ВИДАЛИТИ – зі списку видаляють позначенні студенти.
Кнопка ОЧИСТИТИ – очищує весь список студентів.

## Результат
![ScreenShot](/Wf03_1_t01_CheckedListBox/ScreenShot02.png)

-----

## [Тема: Створення додаткових форм](/Wf04_1_t01_ListView/)

Створити програму за зразком:

![ScreenShot](/Wf04_1_t01_ListView/ScreenShot01.png)

Список повинен містити перелік студентів. Кожен студент містить такі поля: ПІБ, дата народження, середній бал.

При натисканні на кнопку Додати відкривається вікно для введення інформації про нового студента.

При натисканні на кнопку Редагувати відкривається вікно із заповненими полями для редагування.

Всі зміни в списку студентів повинні зберігатись у файл. При завантаженні програма повинна завантажити список студентів.

Проявіть творчість.


## Результат
![ScreenShot](/Wf04_1_t01_ListView/ScreenShot02.png)

-----

## [Годинник](/Wf04_2_t01_%D0%A7%D0%B0%D1%81%D1%8B/)

Написати програму годинник. Програма повинна розміщуватись поверх всіх вікон.

![](/Wf04_2_t01_%D0%A7%D0%B0%D1%81%D1%8B/ScreenShot.png)

-----

## [Заправка «BestOil»](/Wf04_2_t02_%D0%97%D0%B0%D0%BF%D1%80%D0%B0%D0%B2%D0%BA%D0%B0/)

Власник автозаправки «**BestOil**» замовив наступну програму.

Коли автозаправка тільки починає свою діяльність, власник зазвичай хоче  отримувати максимально великий дохід, який планує збільшити за рахунок  додаткових послуг. Тому на автозаправці буде діяти невелике кафе. Але, в той же час  він може найняти тільки одного працівника на посаду касира, а тому призначення  програми - облік продажів бензину і асортименту товарів в мінікафе.

![](/Wf04_2_t02_%D0%97%D0%B0%D0%BF%D1%80%D0%B0%D0%B2%D0%BA%D0%B0/Image_01.png)

**Вимоги до поставленого завдання:**

Для зручності вікно розділене на три частини: перша для здійснення обчислень, що стосуються безпосередньо заправки автомобілів паливом; друга - покупки в міні-кафе; третя частина для обчислення суми оплати.

Отже, **перша група елементів Автозаправка.**

**ComboBox** — список, що випадає з переліком наявного пального. За замовчуванням, відразу при запуску програми повинен бути обраний певний вид пального і в **TextBox** (або наприклад **Label**) повинна відображатися ціна на даний вид продукту. При кожній зміні вибору бензину, ціна в даному полі буде відповідно змінюватися.

Далі, дається можливість вибору: купити пальне, вказавши необхідну кількість літрів або вказавши, на яку суму клієнт буде заправлятися. При цьому, після вибору одного з двох варіантів надання послуги, непотрібне поле стає заблокованим. У разі введення суми грошей, група «До оплати» змінить назву на «До видачі»; замість суми слід виводити кількість літрів, відповідно змінюються одиниці виміру з «грн.» на «л».

**Друга група Міні-кафе.**

Для зручності, всі можливі товари виведені відразу в даній частині. Для кожного продукту передбачені CheckBox з назвою товару, поруч виводиться ціна (неактивний TextBox). При отриманні замовлення для можливості введення кількості замовлених одиниць товару, слід поставити «галочку» в CheckBox навпроти відповідного товару.

**Остання — «До оплати».**

Містить кнопку, яка відповідає за здійснення обчислення і виведення сум у відповідних полях.

Після того, як виведена сума, через (наприклад) 10 секунд повинен з'явитися запит на очистку форми, тобто при появі наступного клієнт: так - все поля приймають значення за замовчуванням, немає - незмінне стан залишається ще на 10 секунд. При виході з програми (закінчився робочий день) повинно з'явитися вікно з повідомленням, якою є загальна сума виручки за даний день. Або цю суму можна відразу виводити в самій формі і змінювати після кожної вправи розрахунку з клієнтом.

Крім цього, надайте формі естетичний вигляд (кольору, шрифти, малюнки...). При обґрунтованої необхідності і цікавому рішенні функціональності програми дозволяється вносити зміни в зовнішній вигляд форми або набір елементів.

## Результат

![](/Wf04_2_t02_%D0%97%D0%B0%D0%BF%D1%80%D0%B0%D0%B2%D0%BA%D0%B0/Image_02.png)

-----

## [Тема: ListBox](/Wf04_3_t01_ListBox/)

Разработать программу «Обработка строк», которая должна выполнять  следующие задачи:

- по щелчку на кнопке «Добавить в список» записывать в «Список  студентов» строку из «Поля ввода», содержащую фамилию и инициалы  студента. 20 фамилий можно записать с помощью «Редактора коллекции  строк»;
- по щелчку на кнопке «Вставить в список» вставлять перед выделенной  строкой в «Списке студентов» строку из «Поля ввода»;
- по щелчку на кнопке «Изменить строку» изменять содержимое  выделенной строки в «Списке студентов» на содержимое из «Поля ввода»;
- по щелчку на кнопке «У далить из списка» удалять строку из «Списка  студентов»;
- по щелчку на кнопке «Определить строку» определять самую  длинную и короткую строку и содержание этих строк вывести в  соответствующие поля.

При разработке интерфейса приложения использовать компоненты  Label, Button, TextBox, Panel и ListBox (один из вариантов интерфейса  представлен на рисунке).

![ScreenShot](/Wf04_3_t01_ListBox/ScreenShot01.png)

## Результат

![ScreenShot](/Wf04_3_t01_ListBox/ScreenShot02.png)

-----

## [Тема: ListBox](/Wf04_3_t02_%D0%92%D1%8B%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B7%D0%BD%D0%B0%D1%87%D0%B5%D0%BD%D0%B8%D0%B9%20%D1%84%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D0%B8/)

Разработать программу вычисления значений функции

![Formula](/Wf04_3_t02_%D0%92%D1%8B%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B7%D0%BD%D0%B0%D1%87%D0%B5%D0%BD%D0%B8%D0%B9%20%D1%84%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D0%B8/ScreenShot04.png)

в диапазоне изменения аргумента х от хн до хк с шагом dx.
В форме предусмотреть ввод значения параметра а, хн, хк, dx.
Ввод исходных данных осуществляется с клавиатуры или путем выбора данных из списка.
Результат решения оформить в виде списка. Если результат решения отсутствует (например, из некорректных исходных данных), то в списке решений должно выдаваться соответствующее сообщение.
При разработке интерфейса приложения использовать компоненты Label, ListBox, Button, Panel и ComboBox (один из вариантов интерфейса представлен на рисунке.

![ScreenShot](/Wf04_3_t02_%D0%92%D1%8B%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B7%D0%BD%D0%B0%D1%87%D0%B5%D0%BD%D0%B8%D0%B9%20%D1%84%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D0%B8/ScreenShot01.png)

![ScreenShot](/Wf04_3_t02_%D0%92%D1%8B%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B7%D0%BD%D0%B0%D1%87%D0%B5%D0%BD%D0%B8%D0%B9%20%D1%84%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D0%B8/ScreenShot02.png)

## Результат

![ScreenShot](/Wf04_3_t02_%D0%92%D1%8B%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%B7%D0%BD%D0%B0%D1%87%D0%B5%D0%BD%D0%B8%D0%B9%20%D1%84%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D0%B8/ScreenShot03.png)

-----

## [П'ятнашки](/Wf05_1_t01_%D0%9F%D1%8F%D1%82%D0%BD%D0%B0%D1%88%D0%BA%D0%B8/)

Розробити гру «П’ятнашки» — популярна головоломка, придумана у 1878 році Ноєм Чепменом. Складається з 15 однакових квадратних пластинок з нанесеними числами від 1 до 15. Пластинки поміщаються в квадратну коробку, довжина сторони якої в чотири рази більша довжини сторони пластинок, відповідно в коробці залишається незаповненим одне квадратне поле. Мета гри — переміщаючи пластинки по коробці добитися впорядковування їх по номерах (як зображено на рисунку), бажано зробивши якомога менше переміщень.

Гра повинна мати меню. В рядку стану вивести інформацію про гравця, його найкращий результат (мінімальна кількість переміщень), поточну кількість переміщень, час гри. Зберігати рекорди користувачів. Зберігати гру, а потім мати змогу продовжити.

Врахуйте, що не кожне поле може бути складено.

![ScreenShot](/Wf05_1_t01_%D0%9F%D1%8F%D1%82%D0%BD%D0%B0%D1%88%D0%BA%D0%B8/ScreenShot01.png)

## Результат

![ScreenShot](/Wf05_1_t01_%D0%9F%D1%8F%D1%82%D0%BD%D0%B0%D1%88%D0%BA%D0%B8/ScreenShot02.png)

-----

## [Тема: Меню. Панель інструментів. Рядок стану](/Wf06_1_t01_%D0%91%D0%BB%D0%BE%D0%BA%D0%BD%D0%BE%D1%82/)

Розробити програму БЛОКНОТ. Добавити меню, панель з кнопками, рядок стану. Кнопки мають виконувати стандартні функції. В рядок стану потрібно добавити: позицію курсора в документі, в рядку, поточний рядок, кількість рядків. Добавити додаткову форму для виведення статистики по тексту: кількість символів, кількість слів, слова, які повторюються більше двох раз (у порядку спадання їх повторень).

Зробіть пошук та заміну по документі.

Для зручності додайте Панель вкладок TabControl.

Для прикладу можна брати Notepad++

![ScreenShot](/Wf06_1_t01_%D0%91%D0%BB%D0%BE%D0%BA%D0%BD%D0%BE%D1%82/ScreenShot01.png)

## Результат

![ScreenShot](/Wf06_1_t01_%D0%91%D0%BB%D0%BE%D0%BA%D0%BD%D0%BE%D1%82/ScreenShot02.png)

-----

## [Тема: GDI+, РУХ](/Wf07_1_t01_%D0%A7%D0%B0%D1%81%D1%8B_GDI%2B/)

Засобами GDI+ намалювати годинник за поданим зразком, який відображає поточний час.

Средствами GDI+ нарисовать часы по данному образцу, которые отображают текущее время.

![ScreenShot](/Wf07_1_t01_%D0%A7%D0%B0%D1%81%D1%8B_GDI%2B/ScreenShot01.png)

## Результат

![ScreenShot](/Wf07_1_t01_%D0%A7%D0%B0%D1%81%D1%8B_GDI%2B/ScreenShot02.png)

