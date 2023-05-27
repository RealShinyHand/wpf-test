<h3>WPF 개인적 연습</h3>
<h4>연습 예제 : https://www.youtube.com/watch?v=V9UdD96iTbk&list=PLA8ZIAm2I03jSfo18F7Y65XusYzDusYu5 </h4>
<br/>
<h4>빈 솔루션 생성</h4>
<h4>dotnet new sln --name (솔루션 이름)</h4>
<h3>1 강</h3>
<ul>
<li>도메인 클래스 생성</li>
<li>서비스 인터페이스 생성</li>
<li>엔티티 프레임 워크 설정,패키지 설치및 DbContext 설정</li>

</ul>
<h4>간략 내역</h4>
<div>
	<p>nuget package 다운로드 : EntityFrameworkCore(7.0.5), EntityFrameWorkCore.SqlServer(7.0.5),EntityFrameworkCore(7.0.5)</p>
	<p>add-migration  명령어 작업 중, EntityFrameworkCore.Design 설치 요구가 발생</p>
	<p>PC에 MSSQL 설치 SA 계정을 사용할 계획</p>
	<p>에러 발생 connection String 수정 : TrustServerCertificate=True 추가
		<code>
		add-migration [사용자 지정 이름] 
		update-database [사용자 지정 이름으로 쓴거]
		</code>
                 add-migration을 통해 db 셋팅할 코드들이 완성되고 update-database를 통해 db에 실제로 적용시킴
	</p>
	
</div>

<h3>

</h3>
