public class FitLabelToText : MonoBehaviour
    {
        private Image panel;

        private ContentSizeFitter _contentSizeFitter;

        private HorizontalLayoutGroup _horizontalLayoutGroup;

        private LayoutElement _label = default;
        public  LayoutElement  Label => _label;
        
        private Text _text = default;
        public  Text  Text => _text;
        
        [SerializeField]
        private int _padding = default;
        public  int  Padding => _padding;

        /// <summary>
        /// テキストにフィットするラベルの生成
        /// </summary>
        private void GenerateFitLabel(Vector3 pos)
        //TODO: カラーの変更　α地の変更　パネルの画像設定　フォントの変更　フォントサイズの変更
        {
            //ラベルを生成後　キャンバスを親に設定
            GameObject PanelObject = new GameObject("FitLabel"); 
            PanelObject.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;

            //panelの各種設定
            panel = PanelObject.AddComponent<Image>();
            panel.rectTransform.localPosition = pos;
            panel.color = Color.gray;

            //Fitに必要なコンポーネントのアタッチ
            _contentSizeFitter = PanelObject.AddComponent<ContentSizeFitter>();
            _horizontalLayoutGroup = PanelObject.AddComponent<HorizontalLayoutGroup>();
            _label = PanelObject.AddComponent<LayoutElement>();
            
            //sizeFitterの設定
            _contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            _contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            //LayoutGroupの設定
            _horizontalLayoutGroup.childControlHeight = true;
            _horizontalLayoutGroup.childControlWidth = true;
            _horizontalLayoutGroup.padding = new RectOffset(_padding,_padding,_padding,_padding);
            _horizontalLayoutGroup.childForceExpandHeight = true;
            _horizontalLayoutGroup.childForceExpandWidth = true;
            
            //テキストの生成後　パネルを親に設定
            GameObject text = new GameObject("text");
            text.transform.parent = PanelObject.transform;
            
            //テキストの各種設定
            _text = text.AddComponent<Text>();
            _text.fontSize = 50;
            _text.font = Font.CreateDynamicFontFromOSFont("Arial",50);
            _text.alignment = TextAnchor.MiddleCenter;
            _text.text = "test";
        }

        private void Start()
        {
            GenerateFitLabel(new Vector3(0,0,0));
            GenerateFitLabel(new Vector3(0,150,0)); 
            GenerateFitLabel(new Vector3(0,-150,0));}
    }
