using reCAPTCHAv3POC.Requests;
using reCAPTCHAv3POC.Responses;

namespace reCAPTCHAv3POC.Interfaces
{
    public interface ISignupService
    {
        Task<SignupResponse> Signup(SignupRequest signupRequest);
    }
}
