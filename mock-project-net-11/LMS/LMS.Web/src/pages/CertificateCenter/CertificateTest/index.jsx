import React, { useContext, useEffect, useState } from 'react'
import { Redirect, useParams } from 'react-router-dom'
import certificateAPI from '../../../api/certificateAPI';
import Clock from '../../StudyCourse/DetailCourse/Clock'
import AuthContext from '../../../store/auth-context';
import ListQuestions from '../../../components/ListQuestion';
export default function CertificateTest() {
    const authContext = useContext(AuthContext);
    const userID = authContext.userId;
    console.log(userID)
    const { certificateId } = useParams();
    const [questions, setQuestion] = useState([]);
    const [quizzId, setQuizzId]= useState(0);
    const [isSubmit, setIsSubmit]= useState(false);
    const [userAnswers, setUserAnswers]= useState({});
    const [resultData,setResultData]= useState({})
    function getSubmitState(state){
        setIsSubmit(state);
    }
    function getUserAnswers(answers){
        setUserAnswers(answers);
    }
    useEffect(async()=>{
        if(isSubmit){
            await certificateAPI.postUserAnswers(userAnswers).then(response=>{
                console.log(response.data.data.quizSubmission);
                setResultData(response.data.data.quizSubmission)
            }).catch(error=>console.log(error));
        }

    },[isSubmit])

    useEffect( () => {
         certificateAPI.getCertificateTest(certificateId).then(response => {
            setQuestion(response.data.objects)
            setQuizzId(response.data.objects[0].quizId)            
        })
    }, [])

    useEffect(() => {
        setInterval(() => {});
      });
      if(isSubmit){
        return (<Redirect to={{
            pathname: "/certificate_center/certifiate_test_result",
            data: { result: resultData }
          }}/>)
    }
    return (
        <>
            <header className="header clearfix">
                <div className="container">
                    <div className="row">
                        <div className="col-12">
                            <div className="back_link">
                                <a href="index.html" className="hde151">Back To Cursus</a>
                                <a href="index.html" className="hde152">Back</a>
                            </div>
                            <div className="ml_item">
                                <div className="main_logo main_logo15" id="logo">
                                    <a href="index.html"><img src="images/logo.svg" alt="" /></a>
                                    <a href="index.html"><img className="logo-inverse" src="images/ct_logo.svg" alt="" /></a>
                                </div>
                            </div>
                            <div className="header_right pr-0">
                                <ul>
                                    <li className="ui top right pointing dropdown">
                                        <a href="#" className="opts_account">
                                            <img src="images/hd_dp.jpg" alt="" />
                                        </a>
                                        <div className="menu dropdown_account">
                                            <div className="channel_my">
                                                <div className="profile_link">
                                                    <img src="images/hd_dp.jpg" alt="" />
                                                    <div className="pd_content">
                                                        <div className="rhte85">
                                                            <h6>Joginder Singh</h6>
                                                            <div className="mef78" title="Verify">
                                                                <i className='uil uil-check-circle'></i>
                                                            </div>
                                                        </div>
                                                        <span><a href="/cdn-cgi/l/email-protection" className="__cf_email__" data-cfemail="cea9afa3aca1a2f7fafd8ea9a3afa7a2e0ada1a3">[email&#160;protected]</a></span>
                                                    </div>
                                                </div>
                                                <a href="my_instructor_profile_view.html" className="dp_link_12">View Instructor Profile</a>
                                            </div>
                                            <div className="night_mode_switch__btn">
                                                <a href="#" id="night-mode" className="btn-night-mode">
                                                    <i className="uil uil-moon"></i> Night mode
                                                    <span className="btn-night-mode-switch">
                                                        <span className="uk-switch-button"></span>
                                                    </span>
                                                </a>
                                            </div>
                                            <a href="instructor_dashboard.html" className="item channel_item">Cursus Dashboard</a>
                                            <a href="sign_in.html" className="item channel_item">Sign Out</a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </header>


            <div className="wrapper _bg4586 _new89">
                <div className="_215b15">
                    <div className="container">
                        <div className="row">
                            <div className="col-lg-12">
                                <div className="title125">
                                    <div className="titleleft">
                                        <div className="ttl121">
                                            <nav aria-label="breadcrumb">
                                                <ol className="breadcrumb">
                                                    <li className="breadcrumb-item"><a href="index.html">Home</a></li>
                                                    <li className="breadcrumb-item"><a href="certification_center.html">Certification Center</a></li>
                                                    <li className="breadcrumb-item active" aria-current="page">WordPress Test View</li>
                                                </ol>
                                            </nav>
                                        </div>
                                    </div>
                                    <div className="titleright">
                                        <a href="certification_center.html" className="blog_link"><i className="uil uil-angle-double-left"></i>Back to Certification Center</a>
                                    </div>
                                </div>
                                <div className="title126">
                                    <h2>WordPress Test View</h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="faq1256">
                    <div className="container">
                        <div className="row">
                            <div className="col-lg-4 col-md-6">
                                <div className="certi_form rght1528">
                                    <div className="test_timer_bg">
                                        <ul className="test_timer_left">
                                            <li>
                                                <div className="timer_time">
                                                    <h4>{questions.length}</h4>
                                                    <p>Questions</p>
                                                </div>
                                            </li>
                                            <li>
                                                <div className="timer_time">
                                                    <Clock key={questions.length * 180} totalTime={questions.length * 180} />
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div className="col-lg-7 col-md-6">
                                {
                                    questions? 
                                    <ListQuestions 
                                    questions={questions} 
                                    quizzId={quizzId}
                                    userId={1}
                                    getSubmitState={getSubmitState} 
                                    getAnswerValue={getUserAnswers}  /> 
                                    :<></>
                                } 
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
