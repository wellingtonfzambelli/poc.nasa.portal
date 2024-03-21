›
WC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\UnitOfWork\UnitOfWork.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )

UnitOfWork) 3
;3 4
public 
sealed 
class 

UnitOfWork 
:  
IUnitOfWork! ,
{		 
private

 
readonly

 
NasaPortalContext

 &
_context

' /
;

/ 0
private &
IPictureOfTheDayRepository &&
_pictureOfTheDayRepository' A
;A B
private !
IDbContextTransaction !
_transaction" .
;. /
public 


UnitOfWork 
( 
NasaPortalContext '
context( /
)/ 0
=>1 3
_context 
= 
context 
; 
public 

async 
Task  
OpenTransactionAsync *
(* +
CancellationToken+ <
ct= ?
)? @
=>A C
_transaction 
= 
await 
_context %
.% &
Database& .
.. /!
BeginTransactionAsync/ D
(D E
ctE G
)G H
;H I
public 

void 
CommitTransaction !
(! "
)" #
=>$ &
_transaction 
. 
Commit 
( 
) 
; 
public 

void 
RollBackTransaction #
(# $
)$ %
=>& (
_transaction 
. 
Rollback 
( 
) 
;  
public 

async 
Task 
	SaveAsync 
(  
CancellationToken  1
ct2 4
)4 5
=>6 8
await 
_context 
. 
SaveChangesAsync '
(' (
ct( *
)* +
;+ ,
public 

void 
Dispose 
( 
) 
=> 
_context 
. 
Dispose 
( 
) 
; 
public   
&
IPictureOfTheDayRepository   %%
PictureOfTheDayRepository  & ?
=>  @ B&
_pictureOfTheDayRepository!! "
=!!# $&
_pictureOfTheDayRepository!!% ?
??!!@ B
new!!C F%
PictureOfTheDayRepository!!G `
(!!` a
_context!!a i
)!!i j
;!!j k
}"" ‰
XC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\UnitOfWork\IUnitOfWork.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )

UnitOfWork) 3
;3 4
public 
	interface 
IUnitOfWork 
: 
IDisposable *
{ &
IPictureOfTheDayRepository %
PictureOfTheDayRepository 8
{9 :
get; >
;> ?
}@ A
Task 
	SaveAsync	 
( 
CancellationToken $
ct% '
)' (
;( )
Task		  
OpenTransactionAsync			 
(		 
CancellationToken		 /
ct		0 2
)		2 3
;		3 4
void

 
CommitTransaction

	 
(

 
)

 
;

 
void 
RollBackTransaction	 
( 
) 
; 
} È!
WC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\Shared\RepositoryBase.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
Shared) /
;/ 0
public 
abstract 
class 
RepositoryBase $
<$ %
TEntity% ,
,, -
TContext. 6
>6 7
:8 9
IRepositoryBase: I
<I J
TEntityJ Q
>Q R
whereS X
TEntityY `
:a b
classc h
whereS X
TContextY a
:b c
	DbContextd m
{		 
public

 

TContext

 
Context

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
public 

RepositoryBase 
( 
TContext "
context# *
)* +
=>, .
Context 
= 
context 
; 
public 

async 
Task 
< 
TEntity 
> 
	FindAsync (
(( )
Guid) -
id. 0
,0 1
CancellationToken2 C
ctD F
)F G
=>H J
await 
Context 
. 
Set 
< 
TEntity !
>! "
(" #
)# $
.$ %
	FindAsync% .
(. /
id/ 1
,1 2
ct3 5
)5 6
;6 7
public 

async 
Task 
< 
IEnumerable !
<! "
TEntity" )
>) *
>* +
FindAllAsync, 8
(8 9
CancellationToken9 J
ctK M
)M N
=>O Q
await 
Context 
. 
Set 
< 
TEntity !
>! "
(" #
)# $
.$ %
ToListAsync% 0
(0 1
ct1 3
)3 4
;4 5
public 

async 
Task 
< 
IEnumerable !
<! "
TEntity" )
>) *
>* +
FindByConditionAync, ?
(? @

Expression 
< 
Func 
< 
TEntity 
,  
bool! %
>% &
>& '

expression( 2
,2 3
CancellationToken4 E
ctF H
)H I
=>J L
await 
Context 
. 
Set 
< 
TEntity !
>! "
(" #
)# $
.$ %
Where% *
(* +

expression+ 5
)5 6
.6 7
ToListAsync7 B
(B C
ctC E
)E F
;F G
public 

async 
Task 
CreateAsync !
(! "
TEntity" )
entity* 0
,0 1
CancellationToken2 C
ctD F
)F G
=>H J
await 
Context 
. 
Set 
< 
TEntity !
>! "
(" #
)# $
.$ %
AddAsync% -
(- .
entity. 4
,4 5
ct6 8
)8 9
;9 :
public 

void 
Update 
( 
TEntity 
entity %
)% &
=>' )
Context 
. 
Set 
< 
TEntity 
> 
( 
) 
. 
Update %
(% &
entity& ,
), -
;- .
public 

void 
Delete 
( 
TEntity 
entity %
)% &
=>' )
Context   
.   
Set   
<   
TEntity   
>   
(   
)   
.   
Remove   %
(  % &
entity  & ,
)  , -
;  - .
}!! þ+
bC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\MessageBroker\SetupMessageBroker.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
MessageBroker) 6
;6 7
public 
sealed 
class 
SetupMessageBroker &
:' (
ISetupMessageBroker) <
{ 
private		 
readonly		 
IConnectionFactory		 '
_connectionFactory		( :
;		: ;
public 

SetupMessageBroker 
( 
string $
hostName% -
,- .
string/ 5
vhost6 ;
,; <
string= C
userNameD L
,L M
stringN T
passwordU ]
)] ^
=>_ a
_connectionFactory 
= 
new  
ConnectionFactory! 2
(2 3
)3 4
{ 	
HostName 
= 
hostName 
,  
VirtualHost 
= 
vhost 
,  
UserName 
= 
userName 
,  
Password 
= 
password 
} 	
;	 

public 

void 
ProduceMessage 
( 
string %
message& -
,- .
string/ 5
queue6 ;
,; <
string= C
exchangeD L
,L M
stringN T

routingKeyU _
)_ `
{ 
using 
( 
IConnection 
conn 
=  !
_connectionFactory" 4
.4 5
CreateConnection5 E
(E F
)F G
)G H
using 
( 
IModel 
channel 
= 
conn  $
.$ %
CreateModel% 0
(0 1
)1 2
)2 3
{ 	
channel 
. 
ExchangeDeclare #
(# $
exchange$ ,
,, -
ExchangeType. :
.: ;
Direct; A
,A B
durableC J
:J K
trueL P
)P Q
;Q R
channel 
. 
QueueDeclare  
(  !
queue! &
,& '
durable( /
:/ 0
true1 5
,5 6
	exclusive7 @
:@ A
falseB G
,G H

autoDeleteI S
:S T
falseU Z
,Z [
	arguments\ e
:e f
nullg k
)k l
;l m
channel 
. 
	QueueBind 
( 
queue #
,# $
exchange% -
,- .

routingKey/ 9
,9 :
null; ?
)? @
;@ A
var 
props 
= 
channel 
.  !
CreateBasicProperties  5
(5 6
)6 7
;7 8
props 
. 

Persistent 
= 
true #
;# $
var   
body   
=   
Encoding   
.    
UTF8    $
.  $ %
GetBytes  % -
(  - .
message  . 5
)  5 6
;  6 7
channel"" 
."" 
BasicPublish""  
(""  !
exchange""! )
,"") *

routingKey""+ 5
,""5 6
props""7 <
,""< =
body""> B
)""B C
;""C D
}## 	
}$$ 
public&& 

string&& 
ConsumeMessage&&  
(&&  !
string&&! '
queue&&( -
)&&- .
{'' 
using(( 
((( 
var(( 

connection(( 
=(( 
_connectionFactory((  2
.((2 3
CreateConnection((3 C
(((C D
)((D E
)((E F
using)) 
()) 
var)) 
channel)) 
=)) 

connection)) '
.))' (
CreateModel))( 3
())3 4
)))4 5
)))5 6
{** 	
channel++ 
.++ 
QueueDeclare++  
(++  !
queue++! &
:++& '
queue++( -
,++- .
durable++/ 6
:++6 7
true++8 <
,++< =
	exclusive++> G
:++G H
false++I N
,++N O

autoDelete++P Z
:++Z [
false++\ a
,++a b
	arguments++c l
:++l m
null++n r
)++r s
;++s t
var,, 
consumer,, 
=,, 
new,, !
EventingBasicConsumer,, 4
(,,4 5
channel,,5 <
),,< =
;,,= >
BasicGetResult.. 
result.. !
=.." #
channel..$ +
...+ ,
BasicGet.., 4
(..4 5
queue..5 :
,..: ;
true..< @
)..@ A
;..A B
if00 
(00 
result00 
==00 
null00 
)00 
return11 
null11 
;11 
return33 
Encoding33 
.33 
UTF833  
.33  !
	GetString33! *
(33* +
result33+ 1
.331 2
Body332 6
.336 7
ToArray337 >
(33> ?
)33? @
)33@ A
;33A B
}44 	
}55 
}66 ù

kC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\MessageBroker\Messages\PictureOfTheDayMsg.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
MessageBroker) 6
.6 7
Messages7 ?
;? @
public 
sealed 
class 
PictureOfTheDayMsg &
{ 
public 

string 
	Copyright 
{ 
get !
;! "
set# &
;& '
}( )
public 

DateTime 
PictureDate 
{  !
get" %
;% &
set' *
;* +
}, -
public 

string 
Explanation 
{ 
get  #
;# $
set% (
;( )
}* +
public 

string 
HdUrl 
{ 
get 
; 
set "
;" #
}$ %
public		 

string		 
Title		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public

 

string

 
Url

 
{

 
get

 
;

 
set

  
;

  !
}

" #
} É
cC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\MessageBroker\ISetupMessageBroker.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
MessageBroker) 6
;6 7
public 
	interface 
ISetupMessageBroker $
{ 
void 
ProduceMessage	 
( 
string 
message &
,& '
string( .
queue/ 4
,4 5
string6 <
exchange= E
,E F
stringG M

routingKeyN X
)X Y
;Y Z
string 

ConsumeMessage 
( 
string  
queue! &
)& '
;' (
}  
‚C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\Domain\Models\PictureOfTheDayAggregate\PictureOfTheDayRepository.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
Domain) /
./ 0
Models0 6
.6 7$
PictureOfTheDayAggregate7 O
;O P
public 
sealed 
class %
PictureOfTheDayRepository -
:. /
RepositoryBase0 >
<> ?
PictureOfTheDay? N
,N O
NasaPortalContextP a
>a b
,b c&
IPictureOfTheDayRepositoryd ~
{		 
public

 
%
PictureOfTheDayRepository

 $
(

$ %
NasaPortalContext

% 6
_context

7 ?
)

? @
:

A B
base

C G
(

G H
_context

H P
)

P Q
{

R S
}

T U
public 

async 
Task 
< 
IList 
< 
PictureOfTheDay +
>+ ,
>, -
GetAllAsync. 9
(9 :
CancellationToken: K
ctL N
)N O
=>P R
await 
base 
. 
Context 
. 
PictureOfTheDay (
.( )
OrderByDescending) :
(: ;
s; <
=>= ?
s@ A
.A B
PictureDateB M
)M N
.N O
ToListAsyncO Z
(Z [
ct[ ]
)] ^
;^ _
public 

async 
Task 
< 
PictureOfTheDay %
>% &
GetByDateAsync' 5
(5 6
DateTime6 >
dateOfPicture? L
,L M
CancellationTokenN _
ct` b
)b c
=>d f
await 
base 
. 
Context 
. 
PictureOfTheDay (
.( )
FirstOrDefaultAsync) <
(< =
s= >
=>? A
sB C
.C D
PictureDateD O
==P R
dateOfPictureS `
,` a
ctb d
)d e
;e f
} ·
C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\Domain\Models\PictureOfTheDayAggregate\PictureOfTheDayBuilder.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
Domain) /
./ 0
Models0 6
.6 7$
PictureOfTheDayAggregate7 O
;O P
public 
sealed 
class "
PictureOfTheDayBuilder *
{ 
public		 

void		 
Build		 
(		 
EntityTypeBuilder		 '
<		' (
PictureOfTheDay		( 7
>		7 8
builder		9 @
)		@ A
{

 
builder 
. 
ToTable 
( 
$str )
)) *
;* +
builder 
. 
HasKey 
( 
x 
=> 
x 
. 
Id  
)  !
;! "
builder 
. 
Property 
( 
x 
=> 
x 
.  
	Copyright  )
)) *
. 
HasColumnType 
( 
$str )
)) *
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
x 
=> 
x 
.  
PictureDate  +
)+ ,
. 
HasColumnType 
( 
$str %
)% &
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
x 
=> 
x 
.  
Explanation  +
)+ ,
. 
HasColumnType 
( 
$str +
)+ ,
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
x 
=> 
x 
.  
HdUrl  %
)% &
. 
HasColumnType 
( 
$str *
)* +
. 

IsRequired 
( 
) 
; 
builder   
.   
Property   
(   
x   
=>   
x   
.    
Title    %
)  % &
.!! 
HasColumnType!! 
(!! 
$str!! )
)!!) *
."" 

IsRequired"" 
("" 
)"" 
;"" 
builder$$ 
.$$ 
Property$$ 
($$ 
x$$ 
=>$$ 
x$$ 
.$$  
Url$$  #
)$$# $
.%% 
HasColumnType%% 
(%% 
$str%% *
)%%* +
.&& 

IsRequired&& 
(&& 
)&& 
;&& 
}'' 
}(( ’
fC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\DI\CommonServiceCollectionExtensions.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
DI) +
;+ ,
public 
static 
class -
!CommonServiceCollectionExtensions 5
{		 
public

 

static

 
void

 &
AddCommonServiceCollection

 1
(

1 2
this

2 6
IServiceCollection

7 I
services

J R
)

R S
{ 

AddLogging 
( 
services 
) 
; 
} 
static 

void 

AddLogging 
( 
IServiceCollection -
services. 6
)6 7
{ 
var 
loggerConfig 
= 
new 
LoggerConfiguration 2
(2 3
)3 4
. 
Enrich 
. 
FromLogContext "
(" #
)# $
. 
WriteTo 
. 
MySQL 
( 
$str k
,k l
$str 
) 
. 
CreateLogger 
( 
) 
; 
services 
. 
AddSingleton 
< 
ILoggerFactory ,
>, -
(- .
new. 1 
SerilogLoggerFactory2 F
(F G
loggerConfigG S
)S T
)T U
;U V
} 
} Á
bC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\Configurations\NasaPortalContext.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
Configurations) 7
;7 8
public 
sealed 
class 
NasaPortalContext %
:& '
	DbContext( 1
{		 
private

 
readonly

 
ILoggerFactory

 #
_loggerFactory

$ 2
;

2 3
public 

NasaPortalContext 
( 
DbContextOptions 
< 
NasaPortalContext *
>* +
options, 3
,3 4
ILoggerFactory 
loggerFactory $
=% &
null' +
) 
: 
base 
( 
options 
) 
=> 
_loggerFactory 
= 
loggerFactory &
;& '
public 

DbSet 
< 
PictureOfTheDay  
>  !
PictureOfTheDay" 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
	protected 
override 
void 
OnConfiguring )
() *#
DbContextOptionsBuilder* A
optionsBuilderB P
)P Q
{ 
if 

( 
_loggerFactory 
!= 
null "
)" #
optionsBuilder 
. 
UseLoggerFactory !
(! "
_loggerFactory" 0
)0 1
. &
EnableSensitiveDataLogging +
(+ ,
false, 1
)1 2
;2 3
} 
	protected 
override 
void 
OnModelCreating +
(+ ,
ModelBuilder, 8
modelBuilder9 E
)E F
{ 
new "
PictureOfTheDayBuilder "
(" #
)# $
.$ %
Build% *
(* +
modelBuilder+ 7
.7 8
Entity8 >
<> ?
PictureOfTheDay? N
>N O
(O P
)P Q
)Q R
;R S
base!! 
.!! 
OnModelCreating!! 
(!! 
modelBuilder!! )
)!!) *
;!!* +
}"" 
}## ®
aC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\Configurations\NamedHttpClients.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
Configurations) 7
;7 8
public 
static 
class 
NamedHttpClients $
{ 
public 

const 
string 
NASA_PORTAL_CLIENT *
=+ ,
$str- ?
;? @
} ò
bC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\Configurations\MessageValidation.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
Configurations) 7
;7 8
public 
static 
class 
MessageValidation %
{ 
public 

static 
( 
string 
code 
, 
string  &
description' 2
)2 3
GeneralError4 @
{A B
getC F
;F G
}H I
=J K
(L M
$strM V
,V W
$strX h
)h i
;i j
public 

static 
( 
string 
code 
, 
string  &
description' 2
)2 3
DateLessThan4 @
{A B
getC F
;F G
}H I
=J K
(L M
$strM V
,V W
$strX ~
)~ 
;	 €
public 

static 
( 
string 
code 
, 
string  &
description' 2
)2 3
NoDataFound4 ?
{@ A
getB E
;E F
}G H
=I J
(K L
$strL U
,U V
$strW c
)c d
;d e
} Ç'
]C:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\Configurations\GlobalParams.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
Configurations) 7
;7 8
public 
static 
class 
GlobalParams  
{ 
public 

static 
string 
ConnectionString )
() *
this* .
IConfiguration/ =
configuration> K
)K L
=>M O
configuration		 
.		 
GetValue		 
<		 
string		 %
>		% &
(		& '
$str		' 9
)		9 :
;		: ;
public 

static 
string 
ApiNasaAddress '
(' (
this( ,
IConfiguration- ;
configuration< I
)I J
=>K M
configuration 
. 
GetValue 
< 
string %
>% &
(& '
$str' 9
)9 :
;: ;
public 

static 
string 
ApiNasaApiKey &
(& '
this' +
IConfiguration, :
configuration; H
)H I
=>J L
configuration 
. 
GetValue 
< 
string %
>% &
(& '
$str' 8
)8 9
;9 :
public 

static 
string 
RedisServer $
($ %
this% )
IConfiguration* 8
configuration9 F
)F G
=>H J
configuration 
. 
GetValue 
< 
string %
>% &
(& '
$str' 5
)5 6
;6 7
public 

static 
string 
RabbitVHost $
($ %
this% )
IConfiguration* 8
configuration9 F
)F G
=>H J
configuration 
. 
GetValue 
< 
string %
>% &
(& '
$str' 7
)7 8
;8 9
public 

static 
string 
RabbitHostname '
(' (
this( ,
IConfiguration- ;
configuration< I
)I J
=>K M
configuration 
. 
GetValue 
< 
string %
>% &
(& '
$str' 8
)8 9
;9 :
public 

static 
string 
RabbitUsername '
(' (
this( ,
IConfiguration- ;
configuration< I
)I J
=>K M
configuration 
. 
GetValue 
< 
string %
>% &
(& '
$str' :
): ;
;; <
public 

static 
string 
RabbitPassord &
(& '
this' +
IConfiguration, :
configuration; H
)H I
=>J L
configuration 
. 
GetValue 
< 
string %
>% &
(& '
$str' :
): ;
;; <
public 

static 
string &
RabbitQueuePictureOfTheDay 3
(3 4
this4 8
IConfiguration9 G
configurationH U
)U V
=>W Y
configuration   
.   
GetValue   
<   
string   %
>  % &
(  & '
$str  ' J
)  J K
;  K L
public!! 

static!! 
string!! )
RabbitExchangePictureOfTheDay!! 6
(!!6 7
this!!7 ;
IConfiguration!!< J
configuration!!K X
)!!X Y
=>!!Z \
configuration"" 
."" 
GetValue"" 
<"" 
string"" %
>""% &
(""& '
$str""' M
)""M N
;""N O
public## 

static## 
string## +
RabbitRoutingKeyPictureOfTheDay## 8
(##8 9
this##9 =
IConfiguration##> L
configuration##M Z
)##Z [
=>##\ ^
configuration$$ 
.$$ 
GetValue$$ 
<$$ 
string$$ %
>$$% &
($$& '
$str$$' P
)$$P Q
;$$Q R
public'' 

static'' 
int'' &
WaitInMillisecondsConsumer'' 0
(''0 1
this''1 5
IConfiguration''6 D
configuration''E R
)''R S
=>''T V
configuration(( 
.(( 
GetValue(( 
<(( 
int(( "
>((" #
(((# $
$str(($ C
)((C D
;((D E
})) Ê
bC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\Cache\Model\PictureOfTheDayRedis.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
Cache) .
.. /
Model/ 4
;4 5
[ 
Document 	
(	 

StorageType
 
= 
StorageType #
.# $
Json$ (
)( )
]) *
public 
sealed 
class  
PictureOfTheDayRedis (
{ 
[ 
RedisIdField 
] 
[ 
Indexed 
] 
public "
Guid# '
Id( *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
[		 
Indexed		 
]		 
public		 
string		 
	Copyright		 %
{		& '
get		( +
;		+ ,
set		- 0
;		0 1
}		2 3
[

 
Indexed

 
]

 
public

 
DateTime

 
PictureDate

 )
{

* +
get

, /
;

/ 0
set

1 4
;

4 5
}

6 7
[ 
Indexed 
] 
public 
string 
Explanation '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
[ 
Indexed 
] 
public 
string 
HdUrl !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 
Indexed 
] 
public 
string 
Title !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 
Indexed 
] 
public 
string 
Url 
{  !
get" %
;% &
set' *
;* +
}, -
} å
UC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\Cache\ICacheService.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
Cache) .
;. /
public 
	interface 
ICacheService 
{ 
Task 
InsertAsync	 
< 
T 
> 
( 
T 
type 
) 
where  %
T& '
:( )
class* /
;/ 0
} ’
TC:\Projetos\poc.nasa.portal\src\Poc.Nasa.Portal.Infrastructure\Cache\CacheService.cs
	namespace 	
Poc
 
. 
Nasa 
. 
Portal 
. 
Infrastructure (
.( )
Cache) .
;. /
public 
sealed 
class 
CacheService  
:! "
ICacheService# 0
{ 
private 
readonly #
RedisConnectionProvider ,
	_provider- 6
;6 7
public		 

CacheService		 
(		 #
RedisConnectionProvider		 /
provider		0 8
)		8 9
=>		: <
	_provider

 
=

 
provider

 
;

 
public 

async 
Task 
InsertAsync !
<! "
T" #
># $
($ %
T% &
type' +
)+ ,
where- 2
T3 4
:5 6
class7 <
{ 
var 

collection 
= 
	_provider "
." #
RedisCollection# 2
<2 3
T3 4
>4 5
(5 6
)6 7
;7 8
await 

collection 
. 
InsertAsync $
($ %
type% )
)) *
;* +
} 
} 