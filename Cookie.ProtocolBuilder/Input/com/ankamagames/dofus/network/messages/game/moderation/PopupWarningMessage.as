package com.ankamagames.dofus.network.messages.game.moderation
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PopupWarningMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6134;
       
      
      private var _isInitialized:Boolean = false;
      
      public var lockDuration:uint = 0;
      
      public var author:String = "";
      
      public var content:String = "";
      
      public function PopupWarningMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6134;
      }
      
      public function initPopupWarningMessage(param1:uint = 0, param2:String = "", param3:String = "") : PopupWarningMessage
      {
         this.lockDuration = param1;
         this.author = param2;
         this.content = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.lockDuration = 0;
         this.author = "";
         this.content = "";
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
         this.serializeAs_PopupWarningMessage(param1);
      }
      
      public function serializeAs_PopupWarningMessage(param1:ICustomDataOutput) : void
      {
         if(this.lockDuration < 0 || this.lockDuration > 255)
         {
            throw new Error("Forbidden value (" + this.lockDuration + ") on element lockDuration.");
         }
         param1.writeByte(this.lockDuration);
         param1.writeUTF(this.author);
         param1.writeUTF(this.content);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PopupWarningMessage(param1);
      }
      
      public function deserializeAs_PopupWarningMessage(param1:ICustomDataInput) : void
      {
         this._lockDurationFunc(param1);
         this._authorFunc(param1);
         this._contentFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PopupWarningMessage(param1);
      }
      
      public function deserializeAsyncAs_PopupWarningMessage(param1:FuncTree) : void
      {
         param1.addChild(this._lockDurationFunc);
         param1.addChild(this._authorFunc);
         param1.addChild(this._contentFunc);
      }
      
      private function _lockDurationFunc(param1:ICustomDataInput) : void
      {
         this.lockDuration = param1.readUnsignedByte();
         if(this.lockDuration < 0 || this.lockDuration > 255)
         {
            throw new Error("Forbidden value (" + this.lockDuration + ") on element of PopupWarningMessage.lockDuration.");
         }
      }
      
      private function _authorFunc(param1:ICustomDataInput) : void
      {
         this.author = param1.readUTF();
      }
      
      private function _contentFunc(param1:ICustomDataInput) : void
      {
         this.content = param1.readUTF();
      }
   }
}
