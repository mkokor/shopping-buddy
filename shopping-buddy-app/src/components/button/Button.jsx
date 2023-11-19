import "./Button.css";

export const Button = ({ message, onClick, backgroundColor }) => {
  return (
    <button
      className="button"
      onClick={onClick}
      style={{ backgroundColor: backgroundColor }}
    >
      {message}
    </button>
  );
};
