…	
FC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Domain\Shared\Utils.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Domain  
.  !
Shared! '
;' (
public 
static 
class 
Utils 
{ 
public 

static 
string 
Truncate !
(! "
this" &
string' -
value. 3
,3 4
int5 8
	maxLength9 B
)B C
{ 
if 

( 
string 
. 
IsNullOrEmpty  
(  !
value! &
)& '
)' (
return) /
value0 5
;5 6
return		 
value		 
.		 
	Substring		 
(		 
$num		  
,		  !
Math		" &
.		& '
Min		' *
(		* +
value		+ 0
.		0 1
Length		1 7
,		7 8
	maxLength		9 B
)		B C
)		C D
;		D E
}

 
} æ
WC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Domain\Models\Shared\IRepositoryBase.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Domain  
.  !
Models! '
.' (
Shared( .
;. /
public 
	interface 
IRepositoryBase  
<  !
TEntity! (
>( )
where* /
TEntity0 7
:8 9
class: ?
{ 
Task 
< 	
TEntity	 
> 
	FindAsync 
( 
Guid  
id! #
,# $
CancellationToken% 6
ct7 9
)9 :
;: ;
Task 
< 	
IEnumerable	 
< 
TEntity 
> 
> 
FindAllAsync +
(+ ,
CancellationToken, =
ct> @
)@ A
;A B
Task		 
<		 	
IEnumerable			 
<		 
TEntity		 
>		 
>		 
FindByConditionAync		 2
(		2 3

Expression

 
<

 
Func

 
<

 
TEntity

 
,

  
bool

! %
>

% &
>

& '

expression

( 2
,

2 3
CancellationToken

4 E
ct

F H
)

H I
;

I J
Task 
CreateAsync	 
( 
TEntity 
entity #
,# $
CancellationToken% 6
ct7 9
)9 :
;: ;
void 
Update	 
( 
TEntity 
entity 
) 
;  
void 
Delete	 
( 
TEntity 
entity 
) 
;  
} ¸
QC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Domain\Models\Shared\BaseModel.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Domain  
.  !
Models! '
.' (
Shared( .
;. /
public 
abstract 
class 
	BaseModel 
{ 
public 

Guid 
Id 
{ 
get 
; 
private !
set" %
;% &
}' (
public 

void 

GenerateId 
( 
) 
=> 
Id 

= 
Guid 
. 
NewGuid 
( 
) 
; 
}		 Ò
iC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Domain\Models\PictureOfTheDayAggregate\PictureOfTheDay.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Domain  
.  !
Models! '
.' ($
PictureOfTheDayAggregate( @
;@ A
public 
sealed 
class 
PictureOfTheDay #
:$ %
	BaseModel& /
{ 
public 

PictureOfTheDay 
( 
) 
{ 
}  
public

 

PictureOfTheDay

 
( 
string 
	copyright 
, 
DateTime 
pictureDate 
, 
string 
explanation 
, 
string 
hdUrl 
, 
string 
title 
, 
string 
url 
) 
{ 
base 
. 

GenerateId 
( 
) 
; 
	Copyright 
= 
	copyright 
; 
PictureDate 
= 
pictureDate !
;! "
Explanation 
= 
explanation !
;! "
HdUrl 
= 
hdUrl 
; 
Title 
= 
title 
; 
Url 
= 
url 
; 
} 
public 

string 
	Copyright 
{ 
get !
;! "
private# *
set+ .
;. /
}0 1
public 

DateTime 
PictureDate 
{  !
get" %
;% &
private' .
set/ 2
;2 3
}4 5
public 

string 
Explanation 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public   

string   
HdUrl   
{   
get   
;   
private   &
set  ' *
;  * +
}  , -
public!! 

string!! 
Title!! 
{!! 
get!! 
;!! 
private!! &
set!!' *
;!!* +
}!!, -
public"" 

string"" 
Url"" 
{"" 
get"" 
;"" 
private"" $
set""% (
;""( )
}""* +
}## ´
tC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Domain\Models\PictureOfTheDayAggregate\IPictureOfTheDayRepository.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Domain  
.  !
Models! '
.' ($
PictureOfTheDayAggregate( @
;@ A
public 
	interface &
IPictureOfTheDayRepository +
:, -
IRepositoryBase. =
<= >
PictureOfTheDay> M
>M N
{ 
Task 
< 	
IList	 
< 
PictureOfTheDay 
> 
>  
GetAllAsync! ,
(, -
CancellationToken- >
ct? A
)A B
;B C
Task 
< 	
PictureOfTheDay	 
> 
GetByDateAsync (
(( )
DateTime) 1
dateOfPicture2 ?
,? @
CancellationTokenA R
ctS U
)U V
;V W
}		 