# ToEnumAttribute

인스펙터에서

string 타입을 지정한 enum 형식으로 보여주는 어트리뷰트이다.

## 예제

```
public enum ItemType
{
	Weapon,
	Shield,
	Armor
}
```


```
public class Item : MonoBehaviour
{
	[ToEnum(typeof(ItemType))] public string itemType;
}
```

![image](https://github.com/solutena/ToEnumAttribute/assets/22467083/1ca747bf-ceea-417f-80cf-3190b27b8180)

## 활용

meta 파일에는 string으로 저장되기 때문에

enum의 중간에 값을 추가해도 값이 변하지 않는다.

```
public enum ItemType
{
	None, //추가
	Weapon,
	Shield,
	Armor
}
```
```
public class Item : MonoBehaviour
{
	[ToEnum(typeof(ItemType))] public string stringType;
	public ItemType enumType;
}
```

### None타입 추가 전

![image](https://github.com/solutena/ToEnumAttribute/assets/22467083/d839b5aa-4ce3-4a55-b625-f56b75d930d4)

### None타입 추가 후

![image](https://github.com/solutena/ToEnumAttribute/assets/22467083/5ed56c08-1d40-4e7d-b698-6f17e1313f72)
