package com.ankamagames.dofus.network.messages.game.context.mount
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MountHarnessColorsUpdateRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6697;
       
      
      private var _isInitialized:Boolean = false;
      
      public var useHarnessColors:Boolean = false;
      
      public function MountHarnessColorsUpdateRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6697;
      }
      
      public function initMountHarnessColorsUpdateRequestMessage(param1:Boolean = false) : MountHarnessColorsUpdateRequestMessage
      {
         this.useHarnessColors = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.useHarnessColors = false;
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
         this.serializeAs_MountHarnessColorsUpdateRequestMessage(param1);
      }
      
      public function serializeAs_MountHarnessColorsUpdateRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.useHarnessColors);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MountHarnessColorsUpdateRequestMessage(param1);
      }
      
      public function deserializeAs_MountHarnessColorsUpdateRequestMessage(param1:ICustomDataInput) : void
      {
         this._useHarnessColorsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MountHarnessColorsUpdateRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_MountHarnessColorsUpdateRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._useHarnessColorsFunc);
      }
      
      private function _useHarnessColorsFunc(param1:ICustomDataInput) : void
      {
         this.useHarnessColors = param1.readBoolean();
      }
   }
}
