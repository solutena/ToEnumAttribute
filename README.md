# ToEnumAttribute

인스펙터에서

string 타입을 지정한 enum 형식으로 보여주는 어트리뷰트입니다.


## 설치

![image](https://github.com/user-attachments/assets/4474a28d-565e-4a10-b867-a3721588660b)

1. URL 복사

![image](https://github.com/user-attachments/assets/f4060f1d-94aa-4a49-b001-e7a5e01316e1)

2. 패키지 매니저에서 Add Package from Git URL 선택

![image](https://github.com/user-attachments/assets/dccb91d5-8c9d-495c-87bf-04b9787e7d63)

3.  복사한 URL로 설치

## 예제

```csharp
public enum ItemType
{
	Weapon,
	Shield,
	Armor
}
```


```csharp
public class Item : MonoBehaviour
{
	[ToEnum(typeof(ItemType))] public string itemType;
}
```

![image](https://github.com/solutena/ToEnumAttribute/assets/22467083/dcc3cef7-8067-49ed-b130-cbcc7239d56f)

enum을 string형식으로 선언 한 후
[ToEnum(typeof(`Enum`))] 을 추가

## 활용

meta 파일에는 string으로 저장되기 때문에

enum의 중간에 값을 추가해도 값이 변하지 않습니다.

```csharp
public enum ItemType
{
	None, //추가
	Weapon,
	Shield,
	Armor
}
```
```csharp
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
