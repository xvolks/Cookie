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
   public class DownloadPartMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 1503;
       
      
      private var _isInitialized:Boolean = false;
      
      public var id:String = "";
      
      public function DownloadPartMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 1503;
      }
      
      public function initDownloadPartMessage(param1:String = "") : DownloadPartMessage
      {
         this.id = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.id = "";
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
         this.serializeAs_DownloadPartMessage(param1);
      }
      
      public function serializeAs_DownloadPartMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.id);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DownloadPartMessage(param1);
      }
      
      public function deserializeAs_DownloadPartMessage(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DownloadPartMessage(param1);
      }
      
      public function deserializeAsyncAs_DownloadPartMessage(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readUTF();
      }
   }
}
