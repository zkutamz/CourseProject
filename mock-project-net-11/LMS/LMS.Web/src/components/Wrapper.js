import { useLocation } from 'react-router-dom';
import Footer from './Footer';

const Wrapper = (props) => {
  const location = useLocation();
  const pathName = location.pathname;

  let classes = `wrapper ${props.minify ? '' : 'wrapper__minify'}`;

  /**
   * Ai lam component nào có class ở div="wrapper <tên class>"
   * Thi thêm vô if bên dưới
   */
  if (pathName.includes('/courses/')) {
    classes += ' _bg4586';
  }
  if (pathName.includes('/profile/')) {
    classes += ' _bg4586';
  }

  return (
    <div className={classes}>
      {props.children}
      <Footer />
    </div>
  );
};

export default Wrapper;
