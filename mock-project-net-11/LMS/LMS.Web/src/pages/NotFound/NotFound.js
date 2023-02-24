import { Button } from "@mui/material"
import { Link } from "react-router-dom"
import { useHistory } from "react-router-dom";

const NotFound = () => {
    const history = useHistory();

    const goToHomePageHandler = () => { history.push('/'); };

    return (
        <div className="wrapper coming_soon_wrapper bg-dark" style={{ height: "100vh", ['margin-left']: 0 }}>
            <div className="container">
                <div className="row">
                    <div className="col-md-12">
                        <div className="cmtk_group">
                            <div className="ct-logo">
                                <a href="index.html"><img src="images/ct_logo.svg" alt="" /></a>
                            </div>
                            <div className="cmtk_dt">
                                <h1 className="title_404">404</h1>
                                <h4 className="thnk_title1">The page you were looking for could not be found.</h4>
                                <Button onClick={goToHomePageHandler} variant="contained" color="primary" size="large">Go To Homepage</Button>
                            </div>
                            <div className="tc_footer_main">
                                <div className="tc_footer_left">
                                    <ul>
                                        <Link>About</Link>
                                        <Link>Press</Link>
                                        <Link>Contact Us</Link>
                                        <Link>Advertise</Link>
                                        <Link>Developers</Link>
                                        <Link>Copyright</Link>
                                        <Link>Privacy PoLinkcy</Link>
                                        <Link>Terms</Link>
                                    </ul>
                                </div>
                                <div className="tc_footer_right">
                                    <p>© 2020 <strong>Cursus</strong>. All Rights Reserved.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default NotFound