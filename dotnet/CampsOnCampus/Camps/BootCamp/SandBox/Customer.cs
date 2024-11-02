using System.Diagnostics;

namespace BootCamp.SandBox
{
    
    // 읽기 전용 레코드
    public record class Customer(string FirstName, string LastName, int Age, string Address, string Description, bool IsQualified);

    // Call Test Class
    public class Runner()
    {
        public void Trigger(object sender, EventArgs args)
        {
            var age = new Random().Next(1, 100); // 테스트 용, 자격 유무에 변동성을 주기 위함..
            
            // 커스토머, 인스턴스 초기화
            // 자격 여부 속성은 초기화시 나이에 의해 결정되고 추후 수정되는 속성이 아니므로 Age 속성에서 별도 처리 할 필요 없이 초기화 시 바로 처리하거나
            // 추후 런타임, 호출 시 나이에 의해 자격 유무를 그때가서 추후 판단할 수 있으므로 불필요한 Property 가 됨..
            // 즉, 데이터베이스 월별 매출 테이블을 가정하면?, 월별 매출만 있으면 되지 별도 컬럼에 합계 컬럼이 있을 필요 없는 것과 같은 맥락..필요할 때 더하면되는 맥락..(Lazy)
            var customer = new Customer("Gil San", "Jang", age, "Seoul", "Good man", age >= 18);
            
            // 출력 샘플 코드..
            Debug.WriteLine(
                $"{customer.FirstName}\t" +
                $"{customer.LastName}\t" +
                $"{customer.Address}\t" +
                $"{customer.Description}\t" +
                $"{customer.Age}\t" +
                $"{customer.IsQualified}");
        }
    }
}