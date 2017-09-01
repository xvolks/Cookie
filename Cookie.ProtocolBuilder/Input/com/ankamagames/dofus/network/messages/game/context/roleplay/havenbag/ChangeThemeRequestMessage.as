package com.ankamagames.dofus.network.messages.game.context.roleplay.havenbag
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChangeThemeRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6639;
       
      
      private var _isInitialized:Boolean = false;
      
      public var theme:int = 0;
      
      public function ChangeThemeRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6639;
      }
      
      public function initChangeThemeRequestMessage(param1:int = 0) : ChangeThemeRequestMessage
      {
         this.theme = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.theme = 0;
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
         this.serializeAs_ChangeThemeRequestMessage(param1);
      }
      
      public function serializeAs_ChangeThemeRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.theme);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChangeThemeRequestMessage(param1);
      }
      
      public function deserializeAs_ChangeThemeRequestMessage(param1:ICustomDataInput) : void
      {
         this._themeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChangeThemeRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_ChangeThemeRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._themeFunc);
      }
      
      private function _themeFunc(param1:ICustomDataInput) : void
      {
         this.theme = param1.readByte();
      }
   }
}
