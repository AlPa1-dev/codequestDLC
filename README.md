## 

## **Wizard Training (Chapter 1\)**

### **Name Validation**

When the player is prompted to enter the wizard’s name:

* The program checks **if the input is null, empty, or whitespace** using  
   `string.IsNullOrWhiteSpace(wizardName)`

* If the string is invalid, the game displays an error and does not format or save the name.

* If valid, the game:

  * Capitalizes the first letter

  * Converts the rest to lowercase  
     This is done by splitting into first character \+ substring:

`char capitalLetter = char.ToUpper(wizardName[0]);`  
`string restName = wizardName.Substring(1).ToLower();`  
`wizardName = string.Concat(capitalLetter, restName);`

*  The cleaned name is then saved in `saveName`.  
   Program

### **Training Logic**

The training lasts **5 days**, each producing two random values:

* Hours meditated (`1–24`)

* Power gained that day (`1–10`)

Power is accumulated in the `trained` variable. After the 5-day loop ends, the wizard receives a title depending on the **final value of `trained`**.

Program

### **Title Assignment Criteria**

The following thresholds determine the title:

| Condition (trained points) | Title Assigned |
| ----- | ----- |
| `< 20` | **"Raoden el Elantr"** |
| `20–29` | **"Zyn el buguejat"** |
| `30–34` | **"Arka nullpointer"** |
| `35–39` | **"Elarion de les brases"** |
| `>= 40` | **"ITB-Wizard el Gris"** |

The check is implemented as a chain of **mutually exclusive `if / else if` blocks**, each printing a narrative message before assigning the title.  
 The final assigned title is stored in `saveTitle`, enabling it to appear in the main menu banner.

Program

---

## **Leveling System (Chapter 2\)**

### **Monster Selection**

A monster is randomly chosen using `rnd.Next(0, 8)` and indexed into:

* A `monsters[]` array (names)

* An `hp[]` array (HP values)  
   This ensures consistent pairing between a monster and its health.  
   Program

### **Dice Combat Logic**

Each attack roll is:

* A random integer from **1 to 6**

* Each number displays an ASCII-art face of a six-sided die

* The damage equals the roll value (1–6)

* Damage is subtracted each turn from the monster’s HP until HP ≤ 0  
   Players cannot fight after reaching **level 5**—the program blocks further combat attempts.  
   Program

### **Level Advancement**

Upon defeating a monster, the player’s level increases by 1 (up to a maximum of 5).  
 The level is stored globally and affects other chapters.

Program

---

## **Mining System (Chapter 3\)**

### **Map Structure**

The mine is represented by:

* `coinMAP[5,5]` storing hidden bit values

* `viewMAP[5,5]` storing symbols for discovered tiles

* A coordinate grid displayed before each attempt

Each tile may contain **0 bits** or a random value between **5 and 50**, assigned at the start.

Program

### **Coordinate Validation**

The program validates X and Y coordinates separately:

* Must be **numbers**

* Must be **between 0 and 4**  
   If invalid, the prompt reappears, and the attempt is not consumed.

### **Mining Outcome**

* If the tile contains bits (`> 0`):

  * Bits are added to `realBits`

  * The map tile is replaced with **💰**

* If empty:

  * The tile is marked **❌**

---

## **Inventory Display (Chapter 4\)**

* If the inventory array has length 0:  
   Prints *“Your inventory is empty.”*

* Otherwise, each item is printed with a leading dash.  
   Inventory persists between chapters as a modifiable string array.  
   Program

---

## **Shop System (Chapter 5\)**

### **Item Selection**

* Items and prices are displayed from parallel arrays (`shopItems[]`, `priceItems[]`).

* Input must be an integer **1–5**.  
   Invalid selections repeat the prompt without exiting the shop.  
   Program

### **Purchase Logic**

* Choice index is converted to `realChoice = choice - 1`.

* If `realBits >= priceItems[realChoice]`, purchase succeeds:

  * A new array is created with \+1 length

  * The item is appended

  * The bit cost is subtracted  
     If not, the game prints *“Not enough bits”* without changing inventory.  
     Program

---

## **Attack Unlocking (Chapter 6\)**

Attacks are stored in a **jagged array**, where each subarray corresponds to a level tier:

`string[][] attacksLvl = { lvl1, lvl2, lvl3, lvl4, lvl5 };`

For a given player level:

* The game prints **all attacks from level 1 up to the current level**

* If level \< 5, it prints a message encouraging continued training  
   Level 5 displays all available spells.  
   Program

---

## **Scroll Decoding (Chapter 7\)**

### **Option Validation**

The player must choose **1, 2, or 3**.  
 If they enter anything else, the game repeats the prompt until valid.

Program

### **Decoding Operations**

The scroll is split into three parts, each associated with a specific decoding action:

#### **1\. Remove Spaces**

Uses `.Replace(" ", "")` on scrollOne.  
 Upon completion, `decodedOne = true`.

#### **2\. Count Magical Runes (Vowels)**

Loops through `scrollTwo`, counting characters contained in the `vowels` string, which includes accented vowels as well.  
 Sets `decodedTwo = true`.

#### **3\. Extract Secret Numerical Code**

Loops through each character in `scrollThree`.  
 If a char is between `'0'` and `'9'`, it's added to `secretCode`.  
 Sets `decodedThree = true`.

### **Completion Check**

After each operation, the program checks:

`if (decodedOne && decodedTwo && decodedThree)`  
    `Console.WriteLine(CompletedDecode);`

Only once all three tasks have been performed (in any order, across multiple visits) does the final completion message appear.

Program

---

## **Program Flow**

The entire game runs inside a `do { … } while (op != 0)` loop until the player chooses **0** to exit, displaying a closing message.  
 All persistent variables—level, bits, name, title, inventory, and scroll flags—live outside the switch-case structure so they carry across chapters.

---

## **Test cases**

**Main menu**

| ID | User Input | Initial State | Expected Result | Error? |
| ----- | ----- | ----- | ----- | ----- |
| **M1** | **`1`** | **N/A** | **Opens Chapter 1** | **No** |
| **M2** | **`9`** | **N/A** | **Shows *“InputErrorMessage”* and returns to menu** | **No** |
| **M3** | **`abc`** | **N/A** | **Shows *“Invalid input…”* and returns to menu** | **No** |
| **M4** | **`-5`** | **N/A** | **Shows *“InputErrorMessage”* and returns to menu** | **No** |

**Chapter1**

| ID | User Input | Initial State | Expected Result | Error? |
| ----- | ----- | ----- | ----- | ----- |
| **C1-A** | ***(empty)*** | **—** | **Shows “You have to type something”, asks for a name again** | **No** |
| **C1-B** | **`M4g0`** | **—** | **Name accepted → “M4g0”** | **No** |
| **C1-C** | **`eldrin`** | **—** | **Name processed → “Eldrin”** | **No** |
| **C1-D** | **`Anna-Maria`** | **—** | **Name accepted** | **No** |
| **C1-E** | **`1234`** | **—** | **Name accepted (program allows it)** | **No** |

**chapter3**

| ID | X Input | Y Input | Expected Result | Error? |
| ----- | ----- | ----- | ----- | ----- |
| **C3-A** | **`2`** | **`3`** | **Valid coordinates → shows 💰 or ❌** | **No** |
| **C3-B** | **`-1`** | **—** | **“the number must be between 0 and 4”, asks again** | **No** |
| **C3-C** | **`10`** | **—** | **“the number must be between 0 and 4”, asks again** | **No** |
| **C3-D** | **`hola`** | **—** | **“Error: you must enter a number”** | **No** |
| **C3-E** | **`0`** | **`hola`** | **“Error: you must enter a number”** | **No** |
| **C3-F** | **`4`** | **`4`** | **Valid input, correct mining behavior** | **No** |

**chapter5**

| ID | User Input | Initial State | Expected Result | Error? |
| ----- | ----- | ----- | ----- | ----- |
| **C5-A** | **`1`** | **realBits \= 50** | **Purchases "Iron Dagger" (cost: 30 bits)** | **No** |
| **C5-B** | **`5`** | **realBits \= 20** | **Purchases “Metal Shield” (cost: 20 bits)** | **No** |
| **C5-C** | **`7`** | **any** | **“Must be a number between 1 and 5”** | **No** |
| **C5-D** | **`abc`** | **any** | **“Error: you must enter a number”** | **No** |
| **C5-E** | **`3`** | **realBits \= 10** | **“Not enough bits”** | **No** |

**chapter7**

| ID | User Input | Interpretation | Expected Result | Error? |
| ----- | ----- | ----- | ----- | ----- |
| **C7-A** | **`1`** | **Remove spaces** | **Prints scrollOne without spaces** | **No** |
| **C7-B** | **`2`** | **Count vowels** | **Prints number of vowels found** | **No** |
| **C7-C** | **`3`** | **Extract digits** | **Prints code: `5638`** | **No** |
| **C7-D** | **`8`** | **Out of range** | **“must be a number between 1 and 3”** | **No** |
| **C7-E** | **`abc`** | **Invalid** | **“Error: you must enter a number”** | **No** |
|  |  |  |  |  |

(Document generated by AI but reviewed and modified by Gerard Alonso)