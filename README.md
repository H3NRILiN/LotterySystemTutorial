# ISUTeaching2019_10_2  

![](https://github.com/H3NRILiN/ISUTeaching2019_10_2/blob/master/Picture/Banner.png)
## 參考文獻: [Adding Random Gameplay Elements](https://docs.unity3d.com/Manual/RandomNumbers.html)  
 [下載Unity專案 : HDRP版本(需要2019.2.7f2版Unity)](https://github.com/H3NRILiN/ISUTeaching2019_10_2/archive/v2.2(HDRP%E7%89%88).zip)  
---




# What: 什麼是抽獎系統?  
抽獎系統會在一堆物件中隨機抽取道具,根據分配的權重,權重愈重的抽到的機率愈高 

---
# Why: 為甚麼用抽獎系統?  
舉例來說  
可以用在遊戲中的獎勵或是花錢抽箱的機制  
或是怪物掉寶也會用到抽獎系統  
簡單來說,遊戲內只要是要增加隨機事件就可以使用這系統 

---
# How: 抽獎的原理為何? 如何運用到程式?  

### 概念

這裡有使用到所謂的機率  
計算方式為`事件數量/樣本空間數量`  
舉例: `100個數字中隨機抽1個數字, 抽到小於等於10的數字`的機率為何?  
這裡的樣本空間就是`{1,2,3,...,98,99,100}`這100個數字  
而事件則是`{1,2,3,...,9,10}`這10個數字  
`所以抽到小於等於10的機率為10/100`, 也可以說是10%  

使用這個概念在程式碼中  
若我們今天要設定一個物件有10%的機率可以被抽到  
我們可以假設抽獎的手就是[Random](https://docs.unity3d.com/ScriptReference/Random.Range.html)  
接著在100中去隨機抽取一個數字  
只要任何數字小於等於10,就表示抽中這個物件  

![](https://github.com/H3NRILiN/ISUTeaching2019_10_2/blob/master/Picture/Random1.png)

---
### 進入今天主題: 
若今天有多個物品要被抽中,每個物品的機率都不同  
那麼要如何去執行這個邏輯?  

#### 根據Unity官方的手冊講解  
可以假設將不同物件在紙條上分成數個分段,分段的長度代表被抽中的比例或權重  
飛鏢就是隨機抽取的值  
###### 官方提供的示意圖
![](https://docs.unity3d.com/uploads/Main/ProbStrip.png)  
 
> 你會疑慮,那我就每個物品用剛剛講的方式都設一個機率不就好了?  
> 事實上是可以的,但是管理上會很麻煩,因為很嚴格的規定你需要將不同物品分配到一個數字範圍內,像是 1到10 , 11到20 等等  
> 這樣才能避免不同物品的機率會有交疊的情況(假如兩個物件出現交疊,萬一抽到交疊到的數字,這樣會一次獲得兩個物件)  
> 而且總數必須為100,每個物品才是你想要得機率,若非100,你必須要手動進行數學計算每個物品機率  

但下方的方式則可以無視權重總數,可以不等於100  
權重的分配也只需要給予一個數字即可,剩下的交給程式計算  
因此管理上很方便  

---
我們將權重視為上面那張紙條的一個區域  
用抽到的數字去比對在哪個區域內,然後就可以獲得該區域的物品  
#### 計算方式:  
假設今天有
```
物品:    權重:    
A         10
B         50
C         50
D         50
E         25
```
將他們設為一個矩陣

我們先求 `總權重` 我們先將物品的所有權重使用for迴圈全部加起來: 10+50+50+50+25 = 185  
接著使用[Random.value](https://docs.unity3d.com/ScriptReference/Random-value.html) (範圍 0.0~1.0) 去和 `總權重` 相乘,獲得一個新的數字: 185 * 0.1263287(假設) =  0.1263287 暫時稱為 `抽取的數字`  
 - 這意味著,我們已經隨機抽取了一個數字,可視為上述紙條中的"飛鏢"已經打中一個位置,我們已經可以從這數字獲得物件,接下來我們與權重做比對  

使用剛剛 `抽取的數字` 使用for迴圈去和 矩陣中的數字 做一一的比對  

若 `抽取的數字` < `目前矩陣位置中的數字` 代表抽中這個物品,可視為飛鏢擊中了這個區域  

但如果 `抽取的數字` > `目前矩陣位置中的數字` 呢? 我們只需要將這個 `目前矩陣位置中的數字` 從 `總權重` 中減掉就好, 然後再繼續到下一個矩陣位置做比對  
 - 簡單來說就是把上述的紙條,把已經比對過的區域拿掉一樣,這樣下次就不會又比對到這個不符合的數字  

若一連串比對下來都不符合的話,抽到的就會是矩陣的最後一個物品
 - 表示我們抽的數字就是屬於在最後一個物品的區域


