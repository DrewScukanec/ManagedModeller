namespace ManagedModeller.Model {
    public abstract class SceneElement {

        #region Name
        private string name;
        public string Name {
            get { return name; }
            set {
                name = value;
                NotifyListeners();
            }
        }
        #endregion

        public delegate void NameUpdated(SceneElement element);
        public event NameUpdated nameUpdated;

        protected void NotifyListeners() {
            if (nameUpdated != null) {
                nameUpdated.Invoke(this);
            }
        }
    }
}
