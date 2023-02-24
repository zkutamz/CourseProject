import { useContext, useState } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import './App.css';
import FeaturedCourse from './components/Course/FeaturedCourse';
import NewestCourse from './components/Course/NewestCourse';
import Footer from './components/Footer';
import ForgotPassword from './components/ForgotPassword';
import Header from './components/Header';
import ReviewsInHome from './components/Home/ReviewsInHome';
import SideBar from './components/SideBar';
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';
import VerifyEmail from './components/VerifyEmail';
import ResetPassword from './components/ResetPassword';
import CheckMail from './components/CheckMail';
import Wrapper from './components/Wrapper';
import About from './pages/About';
import AuthGate from './pages/AuthGate';
import Blog from './pages/Blog';
import CertificateCenter from './pages/CertificateCenter';
import CertificateStartForm from './pages/CertificateCenter/CertificateStartForm';
import CourseDetail from './pages/Course/CourseDetail/courseDetail';
import Review from './pages/Course/CourseDetail/Review';
import Help from './pages/Help/Help';
import HelpQuestion from './pages/HelpQuestion/HelpQuestion';
import HelpSearch from './pages/HelpSearch/HelpSearch';
import { Instructor as InstructorPage } from './pages/Instructor/Instructor';
import NotFound from './pages/NotFound/NotFound';
import Profile from './pages/Profile';
import StudyCourse from './pages/StudyCourse/StudyCourse';
import AuthContext from './store/auth-context';
import CreateCourse from './pages/Course/CreateCourse/CreateCourse';
import Favorites from './pages/Favorites/Favorites';
import { Assignment } from './components/Assignment/Assignment';
import CertificateTest from './pages/CertificateCenter/CertificateTest';
import AddQuiz from './components/Quiz/AddQuiz/AddQuiz';
import AddLesson from './components/Lesson/AddLesson/AddLesson';
import PopularInstructorProfile from './components/User/PopularInstructorProfile';
import SectionForm from './components/Section/sectionForm';
import SectionEditForm from './components/Section/sectionEditForm';
import CertificateResult from './pages/CertificateCenter/CertificateResult'
function App() {
  const authContext = useContext(AuthContext);
  const [openSideBar, setOpenSideBar] = useState(false);

  const openSideBarHandler = () => {
    setOpenSideBar((prev) => !prev);
  };

  return (
    <div className="App">
      <Switch>
        <Route exact path="/">
          <Header onOpenSideBar={openSideBarHandler}></Header>
          <SideBar minify={openSideBar}></SideBar>
          <Wrapper minify={openSideBar}>
            {/* <CourseFeature></CourseFeature> */}
            <FeaturedCourse></FeaturedCourse>
            <NewestCourse></NewestCourse>
            <PopularInstructorProfile></PopularInstructorProfile>
          </Wrapper>
        </Route>

        <Route path="/instructor">
          {authContext.isLoggedIn && authContext.role === 'Instructor' && (
            <InstructorPage minify={openSideBar} onOpenSideBar={openSideBarHandler} />
          )}
          {!authContext.isLoggedIn || (authContext.role !== 'Instructor' && <Redirect to="/" />)}
        </Route>

        <Route path="/courses/:courseId">
          <Header onOpenSideBar={openSideBarHandler} />
          <SideBar minify={openSideBar} />
          <Wrapper minify={openSideBar}>
            <CourseDetail />
          </Wrapper>
        </Route>

        <Route path="/favorites">
          <Header onOpenSideBar={openSideBarHandler} />
          <SideBar minify={openSideBar} />
          <Wrapper minify={openSideBar}>
            <Favorites />
          </Wrapper>
        </Route>

        <Route path="/create-ass">
          <Assignment />
        </Route>
        <Route path="/create-sec">
          <SectionForm />
        </Route>
        <Route path="/edit-sec">
          <SectionEditForm />
        </Route>


        <Route path="/sign-in">
          {!authContext.isLoggedIn && <AuthGate component={SignIn} />}
          {authContext.isLoggedIn && <Redirect to="/" />}
        </Route>

        <Route path="/sign-up">
          {!authContext.isLoggedIn && <AuthGate component={SignUp} />}
          {authContext.isLoggedIn && <Redirect to="/" />}
        </Route>

        <Route path="/forgot-password">
          {!authContext.isLoggedIn && <AuthGate component={ForgotPassword} />}
          {authContext.isLoggedIn && <Redirect to="/sign-in" />}
        </Route>

        <Route path="/verify-email">
          {!authContext.isLoggedIn && <AuthGate component={VerifyEmail} />}
          {authContext.isLoggedIn && <Redirect to="/sign-in" />}
        </Route>

        <Route path="/reset-password">
          {!authContext.isLoggedIn && <AuthGate component={ResetPassword} />}
          {authContext.isLoggedIn && <Redirect to="/sign-in" />}
        </Route>

        <Route path="/check-mail">
          {!authContext.isLoggedIn && <AuthGate component={CheckMail} />}
          {authContext.isLoggedIn && <Redirect to="/" />}
        </Route>

        <Route path="/profile/:userId">
          <Header onOpenSideBar={openSideBarHandler}></Header>
          <SideBar minify={openSideBar}></SideBar>
          <Wrapper minify={openSideBar}>
            <Profile />
          </Wrapper>
        </Route>

        <Route path="/review">
          <Review></Review>
        </Route>

        <Route path="/reviewinhome">
          <ReviewsInHome></ReviewsInHome>
        </Route>

        <Route path="/help">
          <Header onOpenSideBar={openSideBarHandler}></Header>
          <SideBar minify={openSideBar}></SideBar>
          <Wrapper minify={openSideBar}>
            <Help></Help>
          </Wrapper>
        </Route>

        <Route exact path="/faq/:id">
          <Header onOpenSideBar={openSideBarHandler}></Header>
          <SideBar minify={openSideBar}></SideBar>
          <Wrapper minify={openSideBar}>
            <HelpQuestion></HelpQuestion>
          </Wrapper>
        </Route>

        <Route exact path="/help-search/:keyword">
          <Header onOpenSideBar={openSideBarHandler}></Header>
          <SideBar minify={openSideBar}></SideBar>
          <Wrapper minify={openSideBar}>
            <HelpSearch></HelpSearch>
          </Wrapper>
        </Route>

        <Route path="/about">
          <About></About>
        </Route>

        <Route path="/review/:courseId">
          <Review></Review>
        </Route>

        <Route path="/blog">
          <Blog />
          <Footer />
        </Route>

        <Route path="/review">
          <Review></Review>
        </Route>

        <Route path="/addquiz">
          <AddQuiz />
        </Route>

        <Route path="/profile">
          <Header onOpenSideBar={openSideBarHandler}></Header>
          <SideBar minify={openSideBar}></SideBar>
          <Wrapper minify={openSideBar}>
            <Profile />
          </Wrapper>
        </Route>
        <Route path="/addlesson">
          <AddLesson></AddLesson>
        </Route>

        <Route path="/study_course">
          <StudyCourse />
        </Route>
        <Route exact path="/certificate_center">
          <CertificateCenter />
        </Route>
        <Route exact path="/certificate_center/certification_start_form">
          <CertificateStartForm />
        </Route>
        <Route exact path="/certificate_center/certificate_test/:certificateId">
          <CertificateTest />
        </Route>
        <Route exact path="/certificate_center/certifiate_test_result" render={(props) => <CertificateResult {...props}/>} />
        <Route exact path='/create_course'>
          <Header onOpenSideBar={openSideBarHandler}></Header>
          <SideBar minify={openSideBar} page={'InstructorDashboard'}></SideBar>
          <CreateCourse />
          <Footer />
        </Route>

        <Route>
          <NotFound path="*" />
        </Route>
      </Switch>
      {/* <Header></Header>
          <SideBar></SideBar>
          <Profile /> */}
    </div>
  );
}

export default App;
