# 1.cs
### 1. Функционал:
Пользователь задаёт, с какого дня недели начинается месяц.

Пользователь вводит номер дня месяца, чтобы узнать, является ли этот день выходным.

Программа проверяет является ли этот теплый майский день выходным с учетом сдвига недели и выводит соответствующее сообщение.
### 2. Ограничения
Номер дня месяца должен находиться в диапазоне от 1 до 31.

Программа определяет выходные дни только по простым правилам (не поддерживает сложные праздничные календари).
### 3. Возможные ошибки
**Неверная дата:** Если введённый день месяца находится вне допустимого диапазона (меньше 1 или больше 31), программа выводит сообщение:
Неверная дата, попробуйте еще раз.
В этом случае программа предложит ввести день снова.

**Неверный ввод:** Если пользователь введёт некорректные данные (например, текст вместо числа), программа может завершиться с ошибкой FormatException. Пользователю следует вводить только числа.

# 2.cs
### 1. Функционал:
Пользователь вводит сумму, которую хочет снять.
Программа проверяет, можно ли выдать сумму имеющимися купюрами.

Если сумма превышает установленный лимит (150 000 рублей), программа предлагает обратиться в отделение банка.

Если сумма не кратна 100, программа сообщает, что невозможно выдать купюрами.
Выводится количество банкнот каждого номинала для выданной суммы.

## 2. Ограничения
Максимальная сумма для выдачи: 150 000 рублей.
Минимальная номинальная единица: 100 рублей.
Банкомат может выдавать только купюры номиналом: 5000, 2000, 1000, 500, 200, 100 рублей.

### 3. Возможные ошибки
**Слишком большая сумма:** Если введённая сумма превышает 150 000 рублей, программа выводит сообщение: *Слишком много, идите в отделение банка* И запрос на выдачу наличных отменяется.

**Некратная сумма:** Если введённая сумма не кратна 100 (например, 125 рублей), программа сообщает: *Невозможно выдать имеющимися купюрами* Неверный ввод: Если пользователь введёт некорректные данные (например, текст вместо числа), программа может завершиться с ошибкой FormatException. Важно вводить только числа.
