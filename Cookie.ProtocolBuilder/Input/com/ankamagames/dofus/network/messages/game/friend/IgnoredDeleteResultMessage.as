package com.ankamagames.dofus.network.messages.game.friend
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IgnoredDeleteResultMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5677;
       
      
      private var _isInitialized:Boolean = false;
      
      public var success:Boolean = false;
      
      public var name:String = "";
      
      public var session:Boolean = false;
      
      public function IgnoredDeleteResultMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5677;
      }
      
      public function initIgnoredDeleteResultMessage(param1:Boolean = false, param2:String = "", param3:Boolean = false) : IgnoredDeleteResultMessage
      {
         this.success = param1;
         this.name = param2;
         this.session = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.success = false;
         this.name = "";
         this.session = false;
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
         this.serializeAs_IgnoredDeleteResultMessage(param1);
      }
      
      public function serializeAs_IgnoredDeleteResultMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.success);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.session);
         param1.writeByte(_loc2_);
         param1.writeUTF(this.name);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IgnoredDeleteResultMessage(param1);
      }
      
      public function deserializeAs_IgnoredDeleteResultMessage(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
         this._nameFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IgnoredDeleteResultMessage(param1);
      }
      
      public function deserializeAsyncAs_IgnoredDeleteResultMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._nameFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.success = BooleanByteWrapper.getFlag(_loc2_,0);
         this.session = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _nameFunc(param1:ICustomDataInput) : void
      {
         this.name = param1.readUTF();
      }
   }
}
