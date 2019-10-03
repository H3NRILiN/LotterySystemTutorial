# ISUTeaching2019_10_2
 
## 參考文獻: [Adding Random Gameplay Elements](https://docs.unity3d.com/Manual/RandomNumbers.html)  
## [下載Unity專案](https://github.com/H3NRILiN/ISUTeaching2019_10_2/archive/v1.0.zip)  




# What: 什麼是抽獎系統?  
抽獎系統會在一堆物件中隨機抽取道具,根據分配的權重,權重愈重的抽到的機率愈高 

# Why: 為甚麼用抽獎系統?  
舉例來說  
可以用在遊戲中的獎勵或是花錢抽箱的機制  
或是怪物掉寶也會用到抽獎系統  
簡單來說,遊戲內只要是要增加隨機事件就可以使用這系統 

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

![](https://github.com/H3NRILiN/ISUTeaching2019_10_2/blob/master/Random1.png)
### 進入今天主題: 
若今天有多個物品要被抽中,每個物品的機率都不同  
那麼要如何去執行這個邏輯
