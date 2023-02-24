import React from 'react'
import { Switch, Route, useRouteMatch, Link } from 'react-router-dom';
import Header from '../../components/Header';
import Dashboard from '../../components/Instructor/Dashboard/Dashboard'
import SideBar from '../../components/SideBar';
import Wrapper from '../../components/Wrapper';
import Courses from '../../pages/Instructor/Courses/Courses';

export const Instructor = (props) => {
    let match = useRouteMatch();

    return (
        <>
            <Header onOpenSideBar={props.onOpenSideBar} />
            <SideBar page="InstructorDashboard" minify={props.minify} />

            <Wrapper minify={props.minify}>
                <Switch>
                    <Route exact path={`${match.path}`}>
                        <Dashboard />
                    </Route>
                    <Route path={`${match.path}/courses`}>
                        <Courses />
                    </Route>
                </Switch>
            </Wrapper>
        </>
    )
}