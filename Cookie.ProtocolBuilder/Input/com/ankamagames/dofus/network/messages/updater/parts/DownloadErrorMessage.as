package com.ankamagames.dofus.network.messages.updater.parts
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DownloadErrorMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 1513;
       
      
      private var _isInitialized:Boolean = false;
      
      public var errorId:uint = 0;
      
      public var message:String = "";
      
      public var helpUrl:String = "";
      
      public function DownloadErrorMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 1513;
      }
      
      public function initDownloadErrorMessage(param1:uint = 0, param2:String = "", param3:String = "") : DownloadErrorMessage
      {
         this.errorId = param1;
         this.message = param2;
         this.helpUrl = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.errorId = 0;
         this.message = "";
         this.helpUrl = "";
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
         this.serializeAs_DownloadErrorMessage(param1);
      }
      
      public function serializeAs_DownloadErrorMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.errorId);
         param1.writeUTF(this.message);
         param1.writeUTF(this.helpUrl);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DownloadErrorMessage(param1);
      }
      
      public function deserializeAs_DownloadErrorMessage(param1:ICustomDataInput) : void
      {
         this._errorIdFunc(param1);
         this._messageFunc(param1);
         this._helpUrlFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DownloadErrorMessage(param1);
      }
      
      public function deserializeAsyncAs_DownloadErrorMessage(param1:FuncTree) : void
      {
         param1.addChild(this._errorIdFunc);
         param1.addChild(this._messageFunc);
         param1.addChild(this._helpUrlFunc);
      }
      
      private function _errorIdFunc(param1:ICustomDataInput) : void
      {
         this.errorId = param1.readByte();
         if(this.errorId < 0)
         {
            throw new Error("Forbidden value (" + this.errorId + ") on element of DownloadErrorMessage.errorId.");
         }
      }
      
      private function _messageFunc(param1:ICustomDataInput) : void
      {
         this.message = param1.readUTF();
      }
      
      private function _helpUrlFunc(param1:ICustomDataInput) : void
      {
         this.helpUrl = param1.readUTF();
      }
   }
}
