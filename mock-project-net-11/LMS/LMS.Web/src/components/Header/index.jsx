import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import AuthContext from '../../store/auth-context';
import CategoryList from '../Category/CategoryList';
import HeaderRight from '../HeaderRight';
import AuthenticationNav from './AuthenticationNav';

const Header = (props) => {
    const categoriesTemp = [];

    const authContext = useContext(AuthContext);

    const openSideBarHandle = () => {
        props.onOpenSideBar();
    }

    return (
        <>
            <header className="header clearfix">
                <button type="button" id="toggleMenu" className="toggle_menu" onClick={openSideBarHandle} >
                    <i className="uil uil-bars" />
                </button>
                <button id="collapse_menu" className="collapse_menu" onClick={openSideBarHandle}>
                    <i className="uil uil-bars collapse_menu--icon " />
                    <span className="collapse_menu--label" />
                </button>
                <div className="main_logo" id="logo">
                    <Link to='/'>
                        <img src="images/logo.svg" alt="" />
                    </Link>
                    <Link to='/'>
                        <img className="logo-inverse" src="images/ct_logo.svg" alt="" />
                    </Link>
                </div>
                <div className="top-category">
                    <div className="ui compact menu cate-dpdwn">
                        <div className="ui simple dropdown item">
                            <a href="#" className="option_links p-0" title="categories">
                                <i className="uil uil-apps" />
                            </a>
                            <div className="menu dropdown_category5">
                                <CategoryList />
                            </div>
                        </div>
                    </div>
                </div>
                {/* search component */}
                <div className="search120">
                    <div className="ui search">
                        <div className="ui left icon input swdh10">
                            <input
                                className="prompt srch10"
                                type="text"
                                placeholder="Search for Tuts Videos, Tutors, Tests and more.."
                            />
                            <i className="uil uil-search-alt icon icon1" />
                        </div>
                    </div>
                </div>
                {
                    authContext.isLoggedIn &&
                    <HeaderRight />
                }
                {
                    !authContext.isLoggedIn &&
                    <AuthenticationNav />
                }
            </header>
        </>
    );
}

export default Header;
