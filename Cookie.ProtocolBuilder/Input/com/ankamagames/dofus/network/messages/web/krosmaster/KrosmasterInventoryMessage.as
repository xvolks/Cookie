package com.ankamagames.dofus.network.messages.web.krosmaster
{
   import com.ankamagames.dofus.network.types.web.krosmaster.KrosmasterFigure;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class KrosmasterInventoryMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6350;
       
      
      private var _isInitialized:Boolean = false;
      
      public var figures:Vector.<KrosmasterFigure>;
      
      private var _figurestree:FuncTree;
      
      public function KrosmasterInventoryMessage()
      {
         this.figures = new Vector.<KrosmasterFigure>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6350;
      }
      
      public function initKrosmasterInventoryMessage(param1:Vector.<KrosmasterFigure> = null) : KrosmasterInventoryMessage
      {
         this.figures = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.figures = new Vector.<KrosmasterFigure>();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_KrosmasterInventoryMessage(param1);
      }
      
      public function serializeAs_KrosmasterInventoryMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.figures.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.figures.length)
         {
            (this.figures[_loc2_] as KrosmasterFigure).serializeAs_KrosmasterFigure(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_KrosmasterInventoryMessage(param1);
      }
      
      public function deserializeAs_KrosmasterInventoryMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:KrosmasterFigure = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new KrosmasterFigure();
            _loc4_.deserialize(param1);
            this.figures.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_KrosmasterInventoryMessage(param1);
      }
      
      public function deserializeAsyncAs_KrosmasterInventoryMessage(param1:FuncTree) : void
      {
         this._figurestree = param1.addChild(this._figurestreeFunc);
      }
      
      private function _figurestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._figurestree.addChild(this._figuresFunc);
            _loc3_++;
         }
      }
      
      private function _figuresFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:KrosmasterFigure = new KrosmasterFigure();
         _loc2_.deserialize(param1);
         this.figures.push(_loc2_);
      }
   }
}
