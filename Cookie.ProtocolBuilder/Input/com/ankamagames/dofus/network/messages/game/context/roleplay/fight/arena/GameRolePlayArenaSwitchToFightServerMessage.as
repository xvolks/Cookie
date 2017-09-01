package com.ankamagames.dofus.network.messages.game.context.roleplay.fight.arena
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayArenaSwitchToFightServerMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6575;
       
      
      private var _isInitialized:Boolean = false;
      
      public var address:String = "";
      
      public var ports:Vector.<uint>;
      
      public var ticket:Vector.<int>;
      
      private var _portstree:FuncTree;
      
      private var _tickettree:FuncTree;
      
      public function GameRolePlayArenaSwitchToFightServerMessage()
      {
         this.ports = new Vector.<uint>();
         this.ticket = new Vector.<int>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6575;
      }
      
      public function initGameRolePlayArenaSwitchToFightServerMessage(param1:String = "", param2:Vector.<uint> = null, param3:Vector.<int> = null) : GameRolePlayArenaSwitchToFightServerMessage
      {
         this.address = param1;
         this.ports = param2;
         this.ticket = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.address = "";
         this.ports = new Vector.<uint>();
         this.ticket = new Vector.<int>();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         if(HASH_FUNCTION != null)
         {
            HASH_FUNCTION(_loc2_);
         }
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
         this.serializeAs_GameRolePlayArenaSwitchToFightServerMessage(param1);
      }
      
      public function serializeAs_GameRolePlayArenaSwitchToFightServerMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.address);
         param1.writeShort(this.ports.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.ports.length)
         {
            if(this.ports[_loc2_] < 0 || this.ports[_loc2_] > 65535)
            {
               throw new Error("Forbidden value (" + this.ports[_loc2_] + ") on element 2 (starting at 1) of ports.");
            }
            param1.writeShort(this.ports[_loc2_]);
            _loc2_++;
         }
         param1.writeVarInt(this.ticket.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.ticket.length)
         {
            param1.writeByte(this.ticket[_loc3_]);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayArenaSwitchToFightServerMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayArenaSwitchToFightServerMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:int = 0;
         this._addressFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readUnsignedShort();
            if(_loc6_ < 0 || _loc6_ > 65535)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of ports.");
            }
            this.ports.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readVarInt();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readByte();
            this.ticket.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayArenaSwitchToFightServerMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayArenaSwitchToFightServerMessage(param1:FuncTree) : void
      {
         param1.addChild(this._addressFunc);
         this._portstree = param1.addChild(this._portstreeFunc);
         this._tickettree = param1.addChild(this._tickettreeFunc);
      }
      
      private function _addressFunc(param1:ICustomDataInput) : void
      {
         this.address = param1.readUTF();
      }
      
      private function _portstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._portstree.addChild(this._portsFunc);
            _loc3_++;
         }
      }
      
      private function _portsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         if(_loc2_ < 0 || _loc2_ > 65535)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of ports.");
         }
         this.ports.push(_loc2_);
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
