package com.ankamagames.dofus.network.messages.game.approach
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ReloginTokenStatusMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6539;
       
      
      private var _isInitialized:Boolean = false;
      
      public var validToken:Boolean = false;
      
      public var ticket:Vector.<int>;
      
      private var _tickettree:FuncTree;
      
      public function ReloginTokenStatusMessage()
      {
         this.ticket = new Vector.<int>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6539;
      }
      
      public function initReloginTokenStatusMessage(param1:Boolean = false, param2:Vector.<int> = null) : ReloginTokenStatusMessage
      {
         this.validToken = param1;
         this.ticket = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.validToken = false;
         this.ticket = new Vector.<int>();
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
         this.serializeAs_ReloginTokenStatusMessage(param1);
      }
      
      public function serializeAs_ReloginTokenStatusMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.validToken);
         param1.writeVarInt(this.ticket.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.ticket.length)
         {
            param1.writeByte(this.ticket[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ReloginTokenStatusMessage(param1);
      }
      
      public function deserializeAs_ReloginTokenStatusMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:int = 0;
         this._validTokenFunc(param1);
         var _loc2_:uint = param1.readVarInt();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readByte();
            this.ticket.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ReloginTokenStatusMessage(param1);
      }
      
      public function deserializeAsyncAs_ReloginTokenStatusMessage(param1:FuncTree) : void
      {
         param1.addChild(this._validTokenFunc);
         this._tickettree = param1.addChild(this._tickettreeFunc);
      }
      
      private function _validTokenFunc(param1:ICustomDataInput) : void
      {
         this.validToken = param1.readBoolean();
      }
      
      private function _tickettreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarInt();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._tickettree.addChild(this._ticketFunc);
            _loc3_++;
         }
      }
      
      private function _ticketFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readByte();
         this.ticket.push(_loc2_);
      }
   }
}
